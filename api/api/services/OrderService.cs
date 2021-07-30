using api.models;
using api.Repository.Interfaces;
using api.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.services
{
    public class OrderService : IOrderService
    {
        private readonly IUserRepository _userRepository;
           private readonly IOrderRepository _orderRepository;

        public OrderService(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

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
