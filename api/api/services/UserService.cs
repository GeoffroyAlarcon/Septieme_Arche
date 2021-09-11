using api.models;
using api.Repository;
using api.Repository.Interfaces;
using api.services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.services
{
    public class UserService:IUserService
    {
     private readonly   IUserRepository _userRepository; 


    
        public UserService( IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Customer AddCustomer(Customer customer)

        {


            return            _userRepository.AddCustomer(customer);
        }

        public User Auth(string email, string password)
        {
            User result = null;
            try {
                  result =   _userRepository.Auth(email,password);
            }
            catch (Exception ex)
            {
            return null;
                throw;
            }
            return result;
        }

    }
}
