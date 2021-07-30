using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class cart
    {
        public User Purchasser { get; set; }
        public List<lineItemCart> LinesItemCart {get;set;}


        public float? amountCart()
        {
            float amountCart = 0;
            LinesItemCart.ForEach(elt => amountCart = amountCart + (elt.Amount * elt.Item.PriceExcludingTax));

            return amountCart;

        }
    }
}
