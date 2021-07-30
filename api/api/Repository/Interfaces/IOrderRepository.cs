using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.Interfaces
{
  public  interface IOrderRepository
    {
        public List<Order> orders( int userId);
        public void addOrder(Order order);
        public Order findOrderById(int id,int userId);
    }
}
