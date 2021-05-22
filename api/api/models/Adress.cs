using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models { 
    public class Adress
    {
        private int id;
        private string _city;
        private string _postCode;
        private string _country;
        private string _address; // voie
        private string _adressComplement;
        private string _phoneNumber;
        private string _mobilePhoneNumber;

        public Adress()
        {
        }

        public Adress(string city, string postCode, string country, string address, string adressComplement, string phoneNumber, string mobilePhoneNumber)
        {
            _city = city;
            _postCode = postCode;
            _country = country;
            _address = address;
            _adressComplement = adressComplement;
            _phoneNumber = phoneNumber;
            _mobilePhoneNumber = mobilePhoneNumber;
        }
    }
}
