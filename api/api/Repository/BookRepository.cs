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

        public async Task<List<Book>> findAllBook()
        {
           
            List<Book> books = new List<Book>();
            string query = "select titre,URLImage,prix_ht from livres  join articles on articles.id = livres.articleid ORDER BY articles.dateAjoutArticle LIMIT 50  ";
            Db.Connection.Open();

             using var cmd = Db.Connection.CreateCommand();

            cmd.CommandText = query;
            DbDataReader myReader;
            myReader = await cmd.ExecuteReaderAsync();

            while (myReader.Read())
            {

         
                Book book = new Book();
                book.Title = myReader.GetString(1);
                book.Image = myReader.GetString(2);
                book.PriceExcludingTax = myReader.GetDecimal(3);
                books.Add(book);
           }

         await   cmd.DisposeAsync();
            return books;        
        
        
        }

        public async Task<Book> findBookById(int isbn)
        {
            string query = "select isb,nom, titre,prix, auteur, format, poidsenCM,image from livres where isbn =" + isbn + "";

            Book book = new Book();
          await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            DbDataReader rdr;
            rdr = await cmd.ExecuteReaderAsync();
            while (rdr.Read())
            {

            }
            return book;
            throw new NotImplementedException();
        }

        public Book findBookById(int id)
        {
            throw new NotImplementedException();
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
