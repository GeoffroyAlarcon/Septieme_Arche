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

        public List<Book> findAllBook()
        {
           
            List<Book> books = new List<Book>();
            string query = "select isb,nom, titre,prix, auteur, format, poidsenCM,image from livres";
            Db.Connection.Open();
            using var cmd = Db.Connection.CreateCommand();

            cmd.CommandText = query;
            DbDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {

             

                Book book = new Book();
                book.Prix = myReader.GetDecimal(1);
                book.Isbn = myReader.GetString(0);

                books.Add(book);
            }


            return Book;        
        
        
        }

        public Book findById(int isbn)
        {
            string query = "select isb,nom, titre,prix, auteur, format, poidsenCM,image from livres where isbn =" + isbn + "";

            Book book = new Book();
            Db.Connection.Open();
            using var cmd = Db.Connection.CreateCommand();

            MySqlDataReader rdr = cmd.ExecuteReader();
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
