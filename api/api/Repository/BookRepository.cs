using api.models;
using api.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class BookRepository : IBookRepository
    {
        public MySqlConnector Db { get; }
        public BookRepository(MySqlConnector db)
        {
            Db = db;
        }

        public List<Book> findAllBook()
        {
            Db.Connection.Open();

            List<Book> books = new List<Book>() ;
            string query = "select livres.ISBN,estNumerique, titre,URLImage,prix_ht from livres  join articles on articles.id  = livres.articleid  where articles.quantite != 0 or livres.estnumerique = 1  ORDER BY articles.AjoutArticleDate LIMIT 20 ";

            using var cmd = Db.Connection.CreateCommand();
            AuthorRepository authorRepo = new AuthorRepository(Db);
            cmd.CommandText = query;
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                Book book = new Book();
                if ((SByte)myReader["estNumerique"] == 0) book.isDigital = false;

                else book.isDigital = true;
                book.Isbn = myReader["isbn"].ToString();
                book.Title = (string)myReader["titre"];
                book.Image = myReader["URLImage"].ToString();
                book.PriceExcludingTax = (float)myReader["prix_ht"];
                books.Add(book);
            }
            Db.Connection.Close();
            books.ForEach(elt => elt.Authors = authorRepo.AuthorsByISBN(elt.Isbn));
            return books;
        }




        public Book findBookByISBN(string isbn)
        {
            Book book = new Book();
            Db.Connection.Open();
          
            
                MySqlCommand cmd = new MySqlCommand("afficher_livre", Db.Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlParameter param= new MySqlParameter("p_isbn",MySqlDbType.VarChar);
           cmd.Parameters.Add(param).Value = isbn;


            MySqlDataReader myReader = cmd.ExecuteReader();
            if(myReader.Read())
            {
                book.Publishing = new Publishing();
                book.Authors = new List<Author>();
                book.BookGenres = new List<string>();
                    book.Id = (int)myReader["id"];
                    book.Isbn = myReader["isbn"].ToString();
                    book.Title = (string)myReader["titre"];
                    book.NumberOfPages = (int)myReader["pagesNombre"];
                    book.Publishing.Name = myReader["editeur"].ToString();
                    book.Format = myReader["dimension"].ToString();
                    book.Image = myReader["URLimage"].ToString();
                book.Name = myReader["titre"].ToString();
                book.Resume = myReader["description"].ToString();
                book.PriceExcludingTax = (float)myReader["prix_ht"];
                
               if((int) myReader["quantite"] <10 ) // cette condition permettra d'indiqué le nombre restant à l'utilisateur s'il reste moins de 10 livres dans la bdd
                        { 
                    book.Stock = (int)myReader["quantite"];
                }
                else
                {
                    book.Stock = -1;
                }
                book.Publishing.Name = myReader["editeur"].ToString();
                string[] subsListAuhors = myReader["listAuteur"].ToString().Split(',');
                for (int x = 0; x < subsListAuhors.Length; x++)
                {
                    Author author = new Author();
                    string[] firstNameAndLastNameArray = subsListAuhors[x].Split('+');
                    author.FirstName = firstNameAndLastNameArray[0];
                    author.LastName = firstNameAndLastNameArray[1];
                    book.Authors.Add(author);
                }
                string[] subsListGenres = myReader["listGenres"].ToString().Split(',');
                for(int x = 0; x < subsListGenres.Length; x++)
                {
                    book.BookGenres.Add(subsListGenres[x]);
                }
            }
            Db.Connection.Close();
                    return book;
                }
        public DigitalBook findDigitalBookByISBN(string isbn)
        {
            DigitalBook book = new DigitalBook();
            Db.Connection.Open();
            MySqlCommand cmd = new MySqlCommand("afficher_livre_digital", Db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlParameter param = new MySqlParameter("p_isbn", MySqlDbType.VarChar);
            cmd.Parameters.Add(param).Value = isbn;
            MySqlDataReader myReader = cmd.ExecuteReader();
            if(myReader.Read())
            {
                book.Publishing = new Publishing();
                book.Authors = new List<Author>();
                book.BookGenres = new List<string>();
                book.Id = (int)myReader["id"];
                book.Isbn = myReader["isbn"].ToString();
                book.Title = (string)myReader["titre"];
                book.NumberOfPages = (int)myReader["pagesNombre"];
                book.Publishing.Name = myReader["editeur"].ToString();
                book.Format = myReader["dimension"].ToString();
                book.Image = myReader["URLimage"].ToString();
                book.formatDigital = myReader["formatDigital"].ToString();
                book.PriceExcludingTax = (float)myReader["prix_ht"];
                book.Resume = myReader["description"].ToString();
                string[] subsListAuhors = myReader["listAuteur"].ToString().Split(',');
                for (int x = 0; x < subsListAuhors.Length; x++)
                {
                    Author author = new Author();
                    string[] firstNameAndLastNameArray = subsListAuhors[x].Split('+');
                    author.FirstName = firstNameAndLastNameArray[0];
                    author.LastName = firstNameAndLastNameArray[1];
                    book.Authors.Add(author);
                }
                string[] subsListGenres = myReader["listGenres"].ToString().Split(',');
                for (int x = 0; x < subsListGenres.Length; x++)
                {
                    book.BookGenres.Add(subsListGenres[x]);
                }
            }
            Db.Connection.Close();
            return book;
        }
        public bool isDigital(string isbn)
        {
            Db.Connection.Open();

            bool isDigital = true;
            string query = " select estNumerique from livres where livres.isbn = @isbn ";
            using var cmd = Db.Connection.CreateCommand();

            AuthorRepository authorRepo = new AuthorRepository(Db);
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@isbn", isbn);
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();
            
            if (myReader.Read()) { 
            if ((SByte)myReader["estNumerique"] == 0) isDigital = false;
            }
            Db.Connection.Close();
            return isDigital;
        }

        public List<Book> findBytitleOrAuthor(string search)
        {
            Db.Connection.Open();
                List<Book> books = new List<Book>();
            string query = " select livres.ISBN, titre,URLImage,prix_ht from livres  left join articles on articles.id = livres.articleid left join livre_has_auteur on livres.isbn = livre_has_auteur.isbn left join auteurs on livre_has_auteur.auteurId = auteurs.id  where titre like @search or auteurs.nom like @search ORDER BY articles.ajoutArticleDate LIMIT 20" ;
            using var cmd = Db.Connection.CreateCommand();
         
            AuthorRepository authorRepo = new AuthorRepository(Db);
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@search", "%" + search + "%");
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                Book book = new Book();
                book.Isbn = myReader["isbn"].ToString();
                book.Title = (string)myReader["titre"];
                book.Image = myReader["URLImage"].ToString();
         

                book.PriceExcludingTax = (float)myReader["prix_ht"];
                books.Add(book);
            }
            Db.Connection.Close();
            books.ForEach(elt => elt.Authors = authorRepo.AuthorsByISBN(elt.Isbn));
            return books;

        }
    
    }
}
