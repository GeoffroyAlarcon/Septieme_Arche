using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.services.Interfaces
{
    public interface IStockService
    {
        public string  StockIsValid(List<LineItemCart> cart, int userId);
        public void DropPaymentStateByCostumerId(int costumerId);
        public void StockManager(int itemId, int amount);
    }
}
