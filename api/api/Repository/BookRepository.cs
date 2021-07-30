using api.models;
using api.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

        public  List<Book> findAllBook()
        {
             Db.Connection.Open();

            List<Book> books = new List<Book>();
            string query = "select livres.ISBN,estNumerique, titre,URLImage,prix_ht from livres  join articles on articles.id  = livres.articleid  where articles.quantite != 0 ORDER BY articles.dateAjoutArticle LIMIT 20 ";
          
             using var cmd = Db.Connection.CreateCommand();
            AuthorRepository authorRepo = new AuthorRepository(Db);
            cmd.CommandText = query;
            MySqlDataReader myReader;
            myReader =   cmd.ExecuteReader();
           
            while (myReader.Read())
            {
                Book book = new Book();
                if ((SByte)myReader["estNumerique"] == 0) book.isDigital = false;
                
                else book.isDigital = true;
                book.Isbn = myReader["isbn"].ToString();
                book.Title = (string) myReader["titre"];
                book.Image = myReader["URLImage"].ToString();
                book.PriceExcludingTax = (float)myReader["prix_ht"];
                books.Add(book);
            }
            Db.Connection.Close();
            books.ForEach(elt =>  elt.Authors = authorRepo.AuthorsByISBN(  elt.Isbn));
                return books;               
            }
           

        

        public  Book findBookByISBN(string isbn)
        {
            Db.Connection.Open();
            string queryUpdate = " update articles  join livres on articles.id=livres.articleid  set nombreConsultation = nombreConsultation + 1 where isbn = @ISBN";
            string query = "select livres.isbn,articles.id, titre,prix_ht,date_parution,nombre_page,editeur,articles.quantite,  dimension,URLimage from livres join articles on livres.articleId = articles.id where isbn =@ISBN;";
            Book book = new Book();
            book.Publishing = new Publishing();
                        using var cmd = Db.Connection.CreateCommand();
            AuthorRepository authorRepo = new AuthorRepository(Db);
            BookGenreRepository bookGenreRepo = new BookGenreRepository(Db);
            cmd.Parameters.Add(new MySqlParameter("ISBN", isbn));
            cmd.CommandText = queryUpdate;
        
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cmd.CommandText = query;
        
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                book.Id = (int)myReader["id"];
                book.Isbn = myReader["isbn"].ToString();
                book.Title = (string)myReader["titre"];
                book.NumberOfPages = (int)myReader["nombre_page"];
                book.Publishing.Name = myReader["editeur"].ToString();
                book.Format = myReader["dimension"].ToString();
                book.Image = myReader["URLimage"].ToString();
                book.PriceExcludingTax = (float)myReader["prix_ht"];
                book.Stock = (int)myReader["quantite"];
            }
            Db.Connection.Close();
           book.Authors=  authorRepo.AuthorsByISBN(book.Isbn);
            book.BookGenres = bookGenreRepo.getBookGenresByISBN(book.Isbn);
                return book;
        }

        public List<Book> findBytitleOrAuthor(string search)
        {

            Db.Connection.Open();
                List<Book> books = new List<Book>();
            string query = " select livres.ISBN, titre,URLImage,prix_ht from livres  join articles on articles.id = livres.articleid join livre_has_auteur on livres.isbn = livre_has_auteur.isbn join auteurs on livre_has_auteur.auteurId = auteurs.id  where titre like @search or auteurs.nom like @search ORDER BY articles.dateAjoutArticle LIMIT 20" ;
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
