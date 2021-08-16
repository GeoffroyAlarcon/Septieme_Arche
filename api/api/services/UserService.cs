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

        public User Auth(string email, string password)
        {
            User result = new User();
            try {
                  result =   _userRepository.auth(email,password);
             
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

    }
}
