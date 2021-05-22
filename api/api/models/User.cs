using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.models
{
    public class User
    {
        private readonly int _id;
        private String _firstName;
        private String _lastName;
        private String _email;
        private String _password;
     
        public User()
        {
        }

        public User(string firstName, string lastName, string emailAdress, string password)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = emailAdress;
            _password = password;
          
        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }

    }
}