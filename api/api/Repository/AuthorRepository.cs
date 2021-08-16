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
            List<Author> authors = new List<Author>();
            Db.Connection.Open();
            string query = "select nom , prenom, description from auteurs left join livre_has_auteur on auteurs.id = livre_has_auteur.auteurid where isbn="+isbn;
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = query;
            MySqlDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                Author author = new Author();
                author.FirstName = myReader["prenom"].ToString();
                author.LastName = myReader["nom"].ToString();
                author.Resume = myReader["description"].ToString();
                authors.Add(author);
            }
            Db.Connection.Close();
            return authors;
    
        }
    }
 
}
