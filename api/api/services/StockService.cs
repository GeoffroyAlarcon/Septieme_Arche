using api.models;
using api.Repository.Interfaces;
using api.septiemarche.services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.services
{
    public class StockService : IStockService
    {
        public readonly IStockRepository _stockRepository;

        public void DropPaymentStateByCostumerId(int costumerId)
        {
            throw new NotImplementedException();
        }

        public bool StockIsValid(List<lineItemCart> cart, Customer customer)
        {
            foreach (lineItemCart elt in cart)
            {
bool StockIsValid = _stockRepository.StockIsValid(customer.Id, elt.Amount, elt.Item.Id);
                if (StockIsValid == false)
                {
                    _stockRepository.DropPaymentStateByCostumerId(customer.Id);
                    throw new Exception("Votre commande n'a pas pu aboutir, l'article " + elt.Item.Name + " n'est plus disponible à la quantité souhaitée.");
                    return "";
                }
            }
            cart.ForEach(elt => _stockRepository.StockManager(elt.Item.Id, elt.Amount));

        }

        public void StockManager(int itemId, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
