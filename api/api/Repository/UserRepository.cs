using api.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.Common;

namespace api.Repository
{
    public class UserRepository
    {
        internal MySqlConnector Db { get; set; }
       internal UserRepository(MySqlConnector db) {
            Db = db;
        }
        public async Task<List<User>>Auth()
        {
          
            //     string email = user.Email;
            //   string password =   SHA1.Create(user.Password).ToString(); ;
            using var cmd = Db.Connection.CreateCommand();
            string query = "select email, password from  compte_utilisateur where password = 'test' &&  email = 'zlatan@gmail.com'";
            List<User> users = new List<User>();
            cmd.CommandText = query;
            DbDataReader myReader;
            myReader = await cmd.ExecuteReaderAsync();
         
                while (await myReader.ReadAsync())
            {
             
                User findUser = new User();
                findUser.Email = myReader.GetString(0);
                findUser.Password = myReader.GetString(1);
                users.Add( findUser);
                }
       
            return users;
            }


        }


    }

