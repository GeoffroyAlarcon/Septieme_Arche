﻿using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository.Interfaces
{
   public interface IUserRepository
    {
        public User auth();
    }
}