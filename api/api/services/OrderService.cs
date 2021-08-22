﻿using api.models;
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

        public Order findOrderById(int id, int userId)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders(int userId)
        {
            throw new NotImplementedException();
        }

        public string ValidateOrder(List<lineItemCart> cart)
        {
         
            try {
                Order order = new Order();
                foreach (lineItemCart elt in cart)
                {
                    bool StockIsValid = _stockRepository.StockIsValid(elt.Amount, elt.Item.Id);
                    if (StockIsValid == false)
                    {

                      throw new Exception ("Votre commande n'a pas pu aboutir, l'article "+elt.Item.Name + " n'est plus disponible à la quantité souhaitée.");
                        return "";
                    }
                }
                // méthode à implémenter pour la paiement
                // fin de la méthode à implémenter pour le paiement

            // exception si le paiement à échouer

                // si le paiement s'est effecuté alors on procède à la création d'une commande et on déduit les stoks des produits concernés
           
              }
          
            catch (Exception ex) {
            }

            return "";
        }
    
            }
     
    }

