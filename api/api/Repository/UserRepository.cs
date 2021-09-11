using api.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.Common;
using api.Repository.Interfaces;
using System.Text;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        public MySqlConnector Db { get; }
        public UserRepository(MySqlConnector db)
        {
            Db = db;
        }


        public User Auth(string email, string password)
        {
            User findUser = null;
            Db.Connection.Open();
            using var cmd = Db.Connection.CreateCommand();
           string passwordHash = CalculateMD5Hash(password);
            string query = "select email, password, prenom,nom,id from  compte_utilisateur where( email = '" + email +"' and password = '" + passwordHash + "')or( email = '" + email + "' and password = '" + password +"')" ;
            cmd.CommandText = query;
            DbDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                findUser = new User();
                findUser.Id = myReader.GetInt32(4);
                findUser.Email = myReader.GetString(0);
                findUser.Password = myReader.GetString(1);
                findUser.FirstName = myReader.GetString(2);
                findUser.LastName = myReader.GetString(3);

            }
            Db.Connection.Close();


            return findUser;


        }
        public User AuthbyMarketing(string email, string password)
        {
            User findUser = null;
            Db.Connection.Open();
            using var cmd = Db.Connection.CreateCommand();
            string passwordHash = CalculateMD5Hash(password);
            string query = "select email, password, prenom,nom,id,profil_utilisateurId from  compte_utilisateur where( email = '" + email + "' and password = '" + passwordHash + "')or( email = '" + email + "' and password = '" + password + "') and profil_utilisateur=2;";
            cmd.CommandText = query;
            DbDataReader myReader;
            myReader = cmd.ExecuteReader();

            while (myReader.Read())
            {
                findUser = new User();
                findUser.Id = myReader.GetInt32(4);
                findUser.Email = myReader.GetString(0);
                findUser.Password = myReader.GetString(1);
                findUser.FirstName = myReader.GetString(2);
                findUser.LastName = myReader.GetString(3);

            }
            Db.Connection.Close();


            return findUser;


        }

        public Customer AddCustomer(Customer customer)
        {
            Db.Connection.Open();

             customer.Password = CalculateMD5Hash(customer.Password);
            using var cmd = Db.Connection.CreateCommand();
            cmd.Parameters.AddWithValue("@email", customer.Email);
            cmd.Parameters.AddWithValue("@password", customer.Password);
            cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@lastName", customer.LastName);


            string insertUserQuery = "insert into  compte_utilisateur(email,password,nom,prenom, profil_utilisateurId) values (@email,@password,@lastName,@firstName,1)";
            cmd.CommandText = insertUserQuery;
            cmd.ExecuteNonQuery();
           
            customer.Id = (int)cmd.LastInsertedId;
            cmd.Dispose();
      
            string insertAdressQuery = "insert into  adresses(pays,ville,codePostal, voie,VoieNumero,TelephoneNumero,batimentType,interphoneNumero) values ( '" + customer.DeliveryAdress.Country + "', '" + customer.DeliveryAdress.City + "','" + customer.DeliveryAdress.ZipCode + "','" +  customer.DeliveryAdress.Street + "','" + customer.DeliveryAdress.StretNumber + "','" + customer.DeliveryAdress.PoneNumber + "','" + customer.DeliveryAdress.TypeBulding + "','" + customer.DeliveryAdress.DigitalcodeNumber + "')";
            cmd.CommandText = insertAdressQuery;
          
            cmd.ExecuteNonQuery();
            int adressDeliveryID = (int)cmd.LastInsertedId;
            cmd.Dispose();
            cmd.Parameters.AddWithValue("@compteUtilisateurId", customer.Id);
            cmd.Parameters.AddWithValue("@naissanceDate",customer.BirthDayDate.ToString("yyyy-MM-dd HH:mm:ss"));
            string insertCustomerQuery = "insert into clients(compte_utilisateurId, naissanceDate) VALUES ( @compteUtilisateurId,@naissanceDate)";
            cmd.CommandText = insertCustomerQuery;
            cmd.ExecuteNonQuery();
        
            cmd.Dispose();

            cmd.Parameters.AddWithValue("@adressDeliveryId", adressDeliveryID );
            string insertCustomerAdressQuery = "insert into client_has_livraisonadresse(adresseLivraisonId, clientId) VALUES( @adressDeliveryId, @compteUtilisateurId)";
            cmd.CommandText = insertCustomerAdressQuery;
            cmd.ExecuteNonQuery();

            return customer;
            Db.Connection.Close();
        }

        private string CalculateMD5Hash(string input)
        {

            // Primeiro passo, calcular o MD5 hash a partir da string
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Segundo passo, converter o array de bytes em uma string haxadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();

        }

        public int findidbyAuth(User user)
        {
            throw new NotImplementedException();
        }
    }
}

