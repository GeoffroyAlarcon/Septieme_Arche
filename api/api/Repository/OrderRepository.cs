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
        public void addOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order findOrderById(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public List<Order> orders(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
