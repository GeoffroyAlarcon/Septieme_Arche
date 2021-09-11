using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.models
{
    public class LineItemOrder
    {
        public int Id { get; set; }
        public int Aount { get; set; }
        public Item Item { get; set; } 
    }
}
