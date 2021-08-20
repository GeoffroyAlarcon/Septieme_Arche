using api.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.Common;
using api.Repository.Interfaces;
using System.Text;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        public MySqlConnector Db { get; }
        public UserRepository(MySqlConnector db)
        {
            Db = db;
        }
        public User auth(string email, string password)
        {
            User findUser = new User();
            Db.Connection.Open();
            using var cmd = Db.Connection.CreateCommand();
            password = CalculateMD5Hash(password);
            string query = "select email, password, prenom,nom,count(*) from  compte_utilisateur where email = '" + email + "' and password = '" + password + "'";
            cmd.CommandText = query;
            DbDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                int count = myReader.GetInt32(4);
                if (count == 0) return null;

                findUser.Email = myReader.GetString(0);
                findUser.Password = myReader.GetString(1);
                findUser.FirstName = myReader.GetString(2);
                findUser.LastName = myReader.GetString(3);

            }
            Db.Connection.Close();


            return findUser;


        }

        public Customer addCustomer(Customer customer)
        {
            Db.Connection.Open();

             customer.Password = CalculateMD5Hash(customer.Password);
            using var cmd = Db.Connection.CreateCommand();
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@password", customer.Password);
            cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@lastName", customer.LastName);

            string insertUserQuery = "insert into  compte_utilisateur(email,password,nom,prenom) values (@email,@password,@lastName,@firstName)";
            cmd.CommandText = insertUserQuery;
            cmd.ExecuteNonQuery();
            long userId = cmd.LastInsertedId;
            customer.Id = Convert.ToInt32(userId);
            cmd.Parameters.AddWithValue("@naissanceDate", customer.BirthDayDate.Date);
            cmd.Parameters.AddWithValue("@compteUtilisateurId", customer.Id);
            cmd.Dispose();
            string insertCustomerQuery = "insert into client(compte_utilisateurId, naissanceDate) VALUES ( @compteUtilisateurId,@naissanceDate)";
            cmd.CommandText = insertCustomerQuery;
            cmd.ExecuteNonQuery();
            return null;
            Db.Connection.Close();
        }

        private string CalculateMD5Hash(string input)
        {

            // Primeiro passo, calcular o MD5 hash a partir da string
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Segundo passo, converter o array de bytes em uma string haxadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();

        }
    }
}

