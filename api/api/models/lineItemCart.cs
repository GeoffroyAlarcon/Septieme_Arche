using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class lineItemCart
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Item Item { get; set; }
    }
}
