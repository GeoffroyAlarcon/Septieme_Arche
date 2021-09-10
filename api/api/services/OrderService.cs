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
        private readonly IStockRepository _stockRepository;
        public OrderService(IUserRepository userRepository, IOrderRepository orderRepository, IStockRepository stockRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _stockRepository = stockRepository;
        }

        public void addOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order findOrder(int orderId, int userId)
        {
            return _orderRepository.findOrder(orderId, userId);
        }

        public List<Order> FindOrdersByUser(int userId)
        {
        List<Order> result=    _orderRepository.FindOrdersByUser(userId);
            return result;
        }

        public string ValidateOrder(int customerId)
        {
            int newOrderId = 0;
            try {
                Order order = new Order();

                // méthode à implémenter pour la paiement
                // fin de la méthode à implémenter pour le paiement

                // exception si le paiement à échouer

                // si le paiement s'est effecuté alors on procède à la création d'une commande et on déduit les stoks des produits concernés


                newOrderId = _orderRepository.StockManagerAndValideOrder(customerId);

                _stockRepository.DropPaymentStateByCostumerId(customerId);
            }
            catch (Exception ex) {
                _stockRepository.DropPaymentStateByCostumerId(customerId);
                return "error";
            }


            return " votre commande commande numéro N°" + newOrderId + " a bien été prise en compte. Vous retrouverez toutes vos commandes dans votre espace client. ";

        }

    }
     
    }

