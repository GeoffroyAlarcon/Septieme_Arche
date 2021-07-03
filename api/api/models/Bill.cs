using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Bill
    {

        public Bill()
        {
        }


        public int Id { get; }
        public Adress BillingAddress { get; set; }
        public Order Order { get; set; }
    }
}
