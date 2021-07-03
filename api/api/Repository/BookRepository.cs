using api.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class BookRepository : IItem<Book>
    {


        public MySqlConnector Db { get; }
        public BookRepository(MySqlConnector db)
        {
            Db = db;
        }

        public List<Book> findAllBook()
        {
            List<Book> books = new List<Book>();
            string query = "";
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

            }


                throw new NotImplementedException();
        
        
        
        }

        public Book findById(int isbn)
        {
            string query = "select isb,nom, titre,prix, auteur, format, poidsenCM,image from livre where isbn =" + isbn + "";
            MySqlConnection conn = connection.connection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {

            }
            throw new NotImplementedException();
        }
    }
}
