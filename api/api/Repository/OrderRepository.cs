using api.models;
using api.Repository.Interfaces;
using System;
using System.Collections.Generic;
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

       public int addOrder(Order order)
        {
                Db.Connection.Open();


                string query = "insert into commande(clientId) VALUES(@clientId) ";

                using var cmd = Db.Connection.CreateCommand();
                cmd.Parameters.AddWithValue("@clientId", order.Customer.Id);
                cmd.ExecuteNonQuery();
                int result =(int) cmd.LastInsertedId;
                return result;
                Db.Connection.Close();
        }
    }
}
