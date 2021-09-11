using api.septiemarche.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Order
    {
       public Order() { }
        public int Id { get; set; }
        public List<LineItemOrder> Items  { get; set; }
        
        public Customer Customer { get; set; }
        public DateTime OrderDate { get;set; }
    }
}
