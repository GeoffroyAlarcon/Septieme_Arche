using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.services.Interfaces
{
    public interface IStockService
    {
        public string  StockIsValid(List<lineItemCart> cart);
        public void DropPaymentStateByCostumerId(int costumerId);
        public void StockManager(int itemId, int amount);
    }
}
