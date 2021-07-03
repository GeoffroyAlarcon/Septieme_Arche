using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Customer:User
    {
     

        public Adress BillingAdress { get; set; }
        public Adress DeliveryAdress { get; set; }
        public DateTime BirthDayDate { get; set; }

    }
}
