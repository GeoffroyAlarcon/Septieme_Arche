using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Bill
    {
        private int id;
        private Adress billingAddress;
        private Order order;

        public Bill()
        {
        }

        public Bill(int id, Adress billingAddress, Order order)
        {
            this.id = id;
            this.billingAddress = billingAddress;
            this.order = order;
        }

        public int Id { get => id; set => id = value; }
        public Adress BillingAddress { get => billingAddress; set => billingAddress = value; }
        public Order Order { get => order; set => order = value; }
    }
}
