using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.services.Interfaces
{
   public  interface IUserService
    {
        public User Auth();
    }
}
