using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Item
    {
  public Item() { }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }
        public long? NumberOfClicks { get; set; }
        public int? NumberOfSales { get; set; }
        public int?  Stock { get; set; }
        public float PriceExcludingTax { get; set; }



    }
}
