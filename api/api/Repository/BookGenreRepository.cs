using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class BookGenreRepository
    {
        public BookGenreRepository(MySqlConnector db)
        {
            Db = db;
        }


        MySqlConnector Db { get; set; }

        public List<string> getBookGenresByISBN(string isbn)
        {
            List<string> bookGenres = new List<string>();
            Db.Connection.Open();
            string query = "select libelle from genreLivre join livre_has_genreLivre on genrelivre.id =livre_has_genreLivre.genreLivreId   where isbn=" + isbn;
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = query;
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                string bookGenre = myReader["libelle"].ToString();
            
                bookGenres.Add(bookGenre);

            }
            Db.Connection.Close();
            return bookGenres ;

        }
    }

}

