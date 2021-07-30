using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class DigitalBook : Book
    {
        public DigitalBook()
        {
            stockNull();
        }
 string format { get; set; }


        // cette méthode permet d'assigner une valeur nullable afin de ne pas pouvoir gérer le stock s'il s'agit d'un livre numérique
        public void stockNull()
        {
        
            this.Stock = null;

        }
    }
}
