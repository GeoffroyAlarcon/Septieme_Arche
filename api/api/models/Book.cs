using api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{

    public class Book : Item
    {
        public Book()
        {
          
        }

        public string Isbn  {get; set;}
        public bool isDigital { get; set; }
        public int Weight { get; set; }
        public string Format { get; set; }
        public string Title { get; set; }
        public string Resume { get; set; }
        public int NumberOfPages { get; set; }
        public List<Author> Authors { get; set; }
        public List<string> BookGenres { get; set; }
        public Publishing Publishing { get; set; }
    }

}
