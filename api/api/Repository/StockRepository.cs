using api.models;
using api.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repository
{
    public class StockRepository: IStockRepository
    {
        private MySqlConnector Db { get; }

        public StockRepository(MySqlConnector db)
        {
            Db = db;
        }
        public  bool StockIsValid(int userId ,int amount,int itemId)
        {
            Db.Connection.Open();
            // d'abord je cherche dans la table en attente de paiement la quantitée totale de l'article qui est en cours de transaction
            string querySearchQuantite = "select quantitecommandee from  state_Payment_has_article where articleId = @itemId";
            using var cmd = Db.Connection.CreateCommand();
            int quantiteeCommaneStatePayement = 0;
            cmd.Parameters.AddWithValue("@itemId", itemId);
            cmd.CommandText = querySearchQuantite;
       
            MySqlDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                quantiteeCommaneStatePayement = myReader.GetInt32(0);
            }

            Db.Connection.Close();
            Db.Connection.Open();
            // maitenant je regarde si la quantitée commandée  + La quantité en cours de transaction n'est pas supérieur au stock
            string query = "select quantite from articles where Id = @itemId and articles.quantite >=@amount +" + quantiteeCommaneStatePayement;
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@amount", amount);
            myReader = cmd.ExecuteReader();
            if (myReader.Read())
            {
                Db.Connection.Close();
                Db.Connection.Open();
                cmd.Parameters.AddWithValue("@costumerId", userId);
                string queryInsertStatePaiement = "insert into state_Payment_has_article(clientId, quantiteCommandee,articleId ) VALUES(@costumerId, @amount,@itemId) ";
                cmd.CommandText = queryInsertStatePaiement;
                cmd.ExecuteNonQuery();
                Db.Connection.Close();
                return true;
            }

            else
            {
                Db.Connection.Close();
                return false;
            }
         
          

        }
        
     
        public void DropPaymentStateByCostumerId(int costumerId)
        {
            Db.Connection.Open();

      
            using var cmd = Db.Connection.CreateCommand();
            cmd.Parameters.AddWithValue("@costumerId", costumerId);

            string queryDeleteStatePaiement = "delete from state_Payment_has_article where clientId = @costumerId";
            cmd.CommandText = queryDeleteStatePaiement;
            cmd.ExecuteNonQuery();

        }
            
    }


}
