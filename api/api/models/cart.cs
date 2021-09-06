using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Cart
    {
        public Cart() { }
        public Customer Customer { get; set; }
        public List<LineItemCart> LinesItemCart {get;set;}


 
    }
}
