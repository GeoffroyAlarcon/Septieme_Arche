using api.models;
using api.septiemarche.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.Repository.Interfaces
{
    interface IOrderLineRepository
    {
        public List<LineItemOrder> GetAllLineOrderByOrder(int id);
        public int AddLinesOrder(List<LineItemCart> cart); 
    }
}
