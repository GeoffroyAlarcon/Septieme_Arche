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
    public class UserRepository:IUserRepository 
    {
        public MySqlConnector Db { get; }
        public UserRepository(MySqlConnector db) {
            Db = db;
        }
        public  User auth(string email,string password)
        {
            User findUser = new User();
            Db.Connection.Open();
            using var cmd = Db.Connection.CreateCommand();
            string query = "select email, password, count(*) from  compte_utilisateur where email = '" + email + "' and password = '" + password+"'";
            cmd.CommandText = query;
            DbDataReader myReader;
            myReader = cmd.ExecuteReader();
          
                while (myReader.Read())
                {
                int count = myReader.GetInt32(2);
                if (count == 0) return null;

                    findUser.Email = myReader.GetString(0);
                    findUser.Password = myReader.GetString(1);

                }
            Db.Connection.Close();


            return findUser;


       }

        public Customer addCustomer(Customer customer)
        {
            Db.Connection.Open();
      
            var md5 = new MD5CryptoServiceProvider();
            var data = Encoding.ASCII.GetBytes(customer.Password);
     customer.Password  = md5.ComputeHash(data).ToString();
            using var cmd = Db.Connection.CreateCommand();
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@password", customer.Password);
            cmd.Parameters.AddWithValue("@lastfirstNAme", customer.FirstName);
            cmd.Parameters.AddWithValue("@password", customer.LastName);

            string insertUserQuery = "insert into  compte_utilisateur(email,password,lastName,firstName) values (@email,@password,@lastName,@firstname)";
            cmd.CommandText = insertUserQuery;
            cmd.ExecuteNonQuery();
            customer.Id = Convert.ToInt32( cmd.LastInsertedId);
            string insertCustomerQuery = "";
            return null;
      }
    }


    }

