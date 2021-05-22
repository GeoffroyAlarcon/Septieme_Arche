using api.models;
using api.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.services
{
    public class UserService
    {
        private ILogger Logger;
        private readonly UserRepository _userRepository;

        public UserService(ILogger logger, UserRepository userRepository)
        {
            Logger = logger;
            _userRepository = userRepository;
        }

        public  async Task<List<User>> auth()
        {
        
            try {
                Logger.LogInformation($"{DateTime.UtcNow} Tentative de récupération des informations détaillées");
               var   result =   await _userRepository.Auth();
                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "{0} - {1}", DateTime.UtcNow, ex.Message);
                throw;
            }
         
        }

    }
}
