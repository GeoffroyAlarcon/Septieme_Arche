using api.models;
using api.septiemarche.models;
using api.septiemarche.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.Repository
{
    public class OrderLineRepository : IOrderLineRepository
    {

        public OrderLineRepository(MySqlConnector db)
        {
            Db = db;
        }

        MySqlConnector Db { get; set; }


        public int AddLinesOrder(List<LineItemCart> cart)
        {
            throw new NotImplementedException();
        }

        public List<OrderLine> GetAllLineOrderByOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
