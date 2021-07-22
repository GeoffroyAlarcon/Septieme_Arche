using api.models;
using api.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
            string query = "select ISBN, titre,URLImage,prix_ht from livres  join articles on articles.id = livres.articleid ORDER BY articles.dateAjoutArticle LIMIT 20 ";
          
             using var cmd = Db.Connection.CreateCommand();
            AuthorRepository authorRepo = new AuthorRepository(Db);
            cmd.CommandText = query;
            MySqlDataReader myReader;
            myReader =   cmd.ExecuteReader();

            while (myReader.Read())
            {
                Book book = new Book();
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

            string query = "select isbn, titre,prix_ht,date_parution,nombre_page,editeur,  dimension,URLimage from livres join articles on livres.articleId = articles.id where isbn ="+isbn;
            Book book = new Book();
            book.Publishing = new Publishing();
                        using var cmd = Db.Connection.CreateCommand();
            AuthorRepository authorRepo = new AuthorRepository(Db);
            cmd.CommandText = query;
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
          
                book.Isbn = myReader["isbn"].ToString();
                book.Title = (string)myReader["titre"];
                book.NumberOfPages = (int)myReader["nombre_page"];
                book.Publishing.Name = myReader["editeur"].ToString();
                book.Format = myReader["dimension"].ToString();
                book.Image = myReader["URLimage"].ToString();
                book.PriceExcludingTax = (float)myReader["prix_ht"];
            }
            Db.Connection.Close();
           book.Authors=  authorRepo.AuthorsByISBN(book.Isbn);

            return book;
        }


        public void saveBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void updateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void deleteBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
