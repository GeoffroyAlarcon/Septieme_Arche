using api.models;
using api.septiemarche.models;
using api.septiemarche.Repository.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.Repository
{
    public class OrderLineRepository : IOrderLineRepository
    {

        public OrderLineRepository(MySqlConnector db)
        {
            Db = db;
        }

        MySqlConnector Db { get; set; }



        public List<LineItemOrder> GetAllLineOrderByOrder(int orderId)
        {
            Db.Connection.Open();
            List<LineItemOrder> orderLinesArray = new List<LineItemOrder>();
            string query = " select quantiteCommandee,articles.nom as articleNom,articles.prix_ht  from commande_has_article as ligneCommande join articles on articles.id=ligneCommande.articleId where commandeId=" + orderId;
            using var cmd = Db.Connection.CreateCommand();
            cmd.Parameters.AddWithValue("@orderId", orderId);

            cmd.CommandText = query;
            MySqlDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {

                LineItemOrder orderLine = new LineItemOrder();
                orderLine.Amount = (int)myReader["quantiteCommandee"];
                orderLine.Item = new Item();
                orderLine.Item.Name = myReader["articleNom"].ToString();
                orderLine.Item.PriceExcludingTax =(float) myReader["prix_ht"];
                orderLinesArray.Add(orderLine);
            }
            return orderLinesArray;
        }
    }
}
