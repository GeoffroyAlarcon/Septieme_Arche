using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class Conn
    {
         private string server = "localhost";
         private string  database = "septièmeArche";
        private int port = 3306;
         private string userName = "root";
          private string password = "root";
        private   MySqlConnection conn= null;

        public  MySqlConnection connection()
        {
    conn = GetDBConnection(server, port, database, userName, password);

            try
            {

                conn.Open();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return conn;
        }

        public static MySqlConnection
                  GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connString = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conn = new MySqlConnection(connString);

            return conn;
        }
    }
}
