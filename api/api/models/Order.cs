using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Order
    {
        private int id;
        private List<Item> items;
        private Customer customer;
        private DateTime orderDate;

        public Order()
        {
        }

        public Order(int id, List<Item> items, Customer customer, DateTime orderDate)
        {
            this.id = id;
            this.items = items;
            this.customer = customer;
            this.orderDate = orderDate;
        }

        public int Id { get => id; set => id = value; }
        public List<Item> Items { get => items; set => items = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
    }
}
