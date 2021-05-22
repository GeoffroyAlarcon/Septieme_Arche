using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class Item
    {
        private readonly int _id;
        private String nom;
         private readonly string image ;
        private int prix;
        private long clickNumber;
        private int stock;
        private int _priceExcludingTax;
        private int _priceWithTax;


        protected Item( string nom, string image, int prix, long clickNumber, int stock, int priceExcludingTax, int priceWithTax)
        {

            this.nom = nom;
            this.image = image;
            this.prix = prix;
            this.clickNumber = clickNumber;
            this.stock = stock;
            _priceExcludingTax = priceExcludingTax;
            _priceWithTax = priceWithTax;
        }

        public Item( string image, int prix, int stock, int priceExcludingTax)
        {
            this.image = image;
            this.prix = prix;
            this.stock = stock;
            _priceExcludingTax = priceExcludingTax;
        }

        public Item( string image, int prix, int priceExcludingTax)
        {
            this.nom = nom;
            this.image = image;
            this.prix = prix;
            this.stock = stock;
            _priceExcludingTax = priceExcludingTax;
        }

        public int Id => _id;

        public string Nom { get => nom; set => nom = value; }

        public string Image => image;

        public int Prix { get => prix; set => prix = value; }
        public long ClickNumber { get => clickNumber; set => clickNumber = value; }
        public int Stock { get => stock; set => stock = value; }
        public int PriceExcludingTax { get => _priceExcludingTax; set => _priceExcludingTax = value; }
        public int PriceWithTax { get => _priceWithTax; set => _priceWithTax = value; }



    }
}
