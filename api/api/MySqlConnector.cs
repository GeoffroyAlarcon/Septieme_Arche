
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api
{
    public class MySqlConnector : IDisposable
    {
        public MySqlConnection Connection { get; }

        public MySqlConnector(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
