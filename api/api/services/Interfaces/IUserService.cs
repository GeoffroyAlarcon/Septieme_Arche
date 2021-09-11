using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.services.Interfaces
{
   public  interface IUserService
    {

        public User AuthbyMarketing(string email, string password);
        public User Auth(string email, string password);
        public Customer AddCustomer(Customer customer);

    }
}
