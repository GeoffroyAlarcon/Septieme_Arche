using api.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.Common;
using api.Repository.Interfaces;

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
            string query = "select email, password from  compte_utilisateur";
            cmd.CommandText = query;
            DbDataReader myReader;
            myReader = cmd.ExecuteReader();
           
                while (myReader.Read())
                {
                    findUser.Email = myReader.GetString(0);
                    findUser.Password = myReader.GetString(1);

                }
            Db.Connection.Close();


            return findUser;


       } }


    }

