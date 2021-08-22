using api.models;
using api.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class StockRepository: IStockRepository
    {
        private MySqlConnector Db { get; }

        public StockRepository(MySqlConnector db)
        {
            Db = db;
        }
        public  bool StockIsValid(int amount,int itemId)
        {
            Db.Connection.Open();

            string query = "select id from article where id = @itemId  and @amount <= quantite";
            using var cmd = Db.Connection.CreateCommand();

            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@itemId", itemId);

            MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.Read())
            {
                Db.Connection.Close();
                return true;
            }

            else
            {
                Db.Connection.Close();
                return false;
            }
         
          

        }

        public void StockManager(int itemId,int amount)
        {
            Db.Connection.Open();
            string query = "update articles   set quantite =quantite - @amount  here id = @itemId";
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@itemId", itemId);
            cmd.ExecuteNonQuery();
            Db.Connection.Close();
        }

    }


}
