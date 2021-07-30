using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.services.Interfaces
{
  public  interface IOrderService
    {
        public List<Order> orders(int userId);
        public void addOrder(Order order);
        public Order findOrderById(int id, int userId);
    }
}
