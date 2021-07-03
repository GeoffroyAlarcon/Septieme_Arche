using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Author
    {
       

        public Author()
        {
        }

 

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Resume { get; set; }
    }
}
