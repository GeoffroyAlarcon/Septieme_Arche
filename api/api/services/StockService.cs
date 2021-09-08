﻿using api.models;
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
   public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;

        }
        public void DropPaymentStateByCostumerId(int costumerId)
        {
            throw new NotImplementedException();
        }

        public string StockIsValid(List<LineItemCart> cartLines, int userId)
        {

            string isNotValide = "";
            for (int x =0; x<cartLines.Count; x++)
            {
bool StockIsValid = _stockRepository.StockIsValid(userId, cartLines[x].Amount, cartLines[x].Item.Id);
                if (StockIsValid == false)
                {

                   _stockRepository.DropPaymentStateByCostumerId(userId);
                        isNotValide ="l'article" + cartLines[x].Item.Name + " dans votre panier n'est plus disponible à la quantité souhaitée";
                    return isNotValide;
                }
                
            }
             return "";

        }

        public void StockManager(int itemId, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
