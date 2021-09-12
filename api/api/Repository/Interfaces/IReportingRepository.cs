using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.Repository.Interfaces
{
    public interface IReportingRepository
    {
        public List<Item> Stockisempty();
        public List<Item> TopTenItemMostSold();
        public List<Item> TopTenItemMostView();

    }
}
