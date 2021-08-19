using api.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class AuthorRepository
    {
       public AuthorRepository(MySqlConnector db)
        {
            Db = db;
        }

        MySqlConnector Db { get; set; }

        public List<Author> AuthorsByISBN(string isbn)
        {
            Db.Connection.Open();
            List<Author> authors = new List<Author>();
    
            using var cmd = Db.Connection.CreateCommand();
            string query = "select nom, prenom from auteurs join livre_has_auteur on auteurs.id = livre_has_auteur.auteurid where isbn= '"+isbn + "'";

            cmd.CommandText = query;
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                Author author = new Author();
                author.FirstName = myReader["prenom"].ToString();
                author.LastName = myReader["nom"].ToString();
                authors.Add(author);
            }
            Db.Connection.Close();
            return authors;
    
        }
    }
 
}
