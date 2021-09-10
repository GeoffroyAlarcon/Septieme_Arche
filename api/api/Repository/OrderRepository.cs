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
    public class OrderRepository :  IOrderRepository
    {
        public OrderRepository(MySqlConnector db)
        {
            Db = db;
        }

        MySqlConnector Db { get; set; }

        public Order findOrder(int orderId, int userId)
        {
            Db.Connection.Open();
                Order order = new Order(); ;
            string query = "select id, commandeDate from commandes where clientId=@userId and id= @orderId";
            using var cmd = Db.Connection.CreateCommand();
            cmd.Parameters.AddWithValue("@orderId", orderId);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.CommandText = query;
            MySqlDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                
                order.OrderDate = (DateTime)myReader["commandeDate"];
                order.Id = (int)myReader["id"];
            }
            return order;
            Db.Connection.Close();
        }

        public List<Order> FindOrdersByUser(int userId)
        {
            List<Order> orders = new List<Order>();
            Db.Connection.Open();
            string query = "select id, commandeDate from commandes where clientId=@userId";
            using var cmd = Db.Connection.CreateCommand();
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.CommandText = query;
           MySqlDataReader myReader= cmd.ExecuteReader();
            while (myReader.Read())
            {
                Order order = new Order();
                order.OrderDate =(DateTime) myReader["commandeDate"];
                order.Id = (int)myReader["id"];
                orders.Add(order);
            }
            return orders;
            Db.Connection.Close();
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
