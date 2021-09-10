using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.Interfaces
{
  public  interface IOrderRepository
    {   
        public List<Order> FindOrdersByUser( int userId);
        public int StockManagerAndValideOrder(int clientId);
        public Order findOrder(int orderId,int userId);
    }
}
