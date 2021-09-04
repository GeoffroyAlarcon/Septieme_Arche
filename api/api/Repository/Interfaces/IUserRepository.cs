using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.Interfaces
{
   public interface IUserRepository
    {
        public User auth(string email, string password);
        public Customer addCustomer(Customer customer);
        public int findidbyAuth(User user);

    }
}
