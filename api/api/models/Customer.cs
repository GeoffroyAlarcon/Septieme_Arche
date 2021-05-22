using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Customer:User
    {
        private Adress _billingAdress = new Adress();
        private Adress _deliveryAdress = new Adress();
        private DateTime _birthDayDate = new DateTime();

        public Customer(string firstName, string lastName, string emailAdress, string password, Adress billingAdress = null, Adress deliveryAdress = null, DateTime birthDayDate = default) : base(firstName, lastName, emailAdress, password)
        {
            _billingAdress = billingAdress;
            _deliveryAdress = deliveryAdress;
            _birthDayDate = birthDayDate;
        }

        public Adress BillingAdress1 { get => _billingAdress; set => _billingAdress = value; }
        public Adress DeliveryAdress1 { get => _deliveryAdress; set => _deliveryAdress = value; }
        public DateTime BirthDayDate1 { get => _birthDayDate; set => _birthDayDate = value; }
    }
}
