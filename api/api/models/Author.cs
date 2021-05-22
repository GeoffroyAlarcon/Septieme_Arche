using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Author
    {
        private int id;
        private string nom;
        private string prenom;
        private string resume;

        public Author()
        {
        }

        public Author(int id, string nom, string prenom, string resume)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.resume = resume;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Resume { get => resume; set => resume = value; }
    }
}
