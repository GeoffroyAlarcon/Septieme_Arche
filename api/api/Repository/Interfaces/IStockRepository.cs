using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.Interfaces
{
    public interface IStockRepository
    {
        public bool StockIsValid(int userId,int amount, int itemId);
        public void DropPaymentStateByCostumerId(int costumerId);

    }
}
