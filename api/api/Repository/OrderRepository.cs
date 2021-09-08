using api.models;
using api.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository(MySqlConnector db)
        {
            Db = db;
        }

        MySqlConnector Db { get; set; }

        public Order findOrderById(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public List<Order> orders(int userId)
        {
            throw new NotImplementedException();
        }

        // cette méthode permet d'appeler une procédure stocket qui valide la commande et actualise le stock. 
       public int StockManagerAndValideOrder(int clientId)
        {
            Db.Connection.Open();

            int totalOrder = 0;
            MySqlCommand cmd = new MySqlCommand("gestion_stock", Db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            MySqlParameter param = new MySqlParameter("param_clientId", MySqlDbType.Int32);
            cmd.Parameters.Add(param).Value = clientId;


            MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.Read())
            {
                totalOrder =myReader.GetInt32(0);
            }
            return totalOrder;
        }

    }
}
