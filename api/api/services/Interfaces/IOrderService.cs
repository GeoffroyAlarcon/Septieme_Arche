using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.services.Interfaces
{
  public  interface IOrderService
    {
        public List<Order> FindOrdersByUser(int userId);
        public Order findOrder(int orderId,int userId);
        public void addOrder(Order order);
        public string ValidateOrder(int customerId);
    }
}
