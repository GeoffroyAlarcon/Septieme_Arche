using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.services.Interfaces
{
 public   interface IReportingService
    {
        public List<Item> Stockisempty();
        public List<Item> TopTenItemMostSold();
        public List<Item> TopTenItemMostView();
    }
}
