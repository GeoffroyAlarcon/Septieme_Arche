using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class StockRepository
    {
        private MySqlConnector Db { get; }

        public StockRepository(MySqlConnector db)
        {
            Db = db;
        }
        public string  ManagerStock(Item item)
        {
            Db.Connection.Open();
            string query = "select * ";

            using var cmd = Db.Connection.CreateCommand();

            cmd.CommandText = query;

            return "";
        }

    }


}
