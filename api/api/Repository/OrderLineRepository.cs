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
            string query = " select quantiteCommandee,articles.nom,articles.prix_ht  from commande_has_article as ligneCommande join articles on articles.id=ligneCommande.articleId where commandeId=5;";
            using var cmd = Db.Connection.CreateCommand();
            cmd.Parameters.AddWithValue("@orderId", orderId);

            cmd.CommandText = query;
            MySqlDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {

                LineItemOrder orderLine = new LineItemOrder();
                orderLine.Aount = (int)myReader["quantiteCommandee"];
                orderLine.Item.Name = myReader["articles.nom"].ToString();
                orderLine.Item.PriceExcludingTax =(float) myReader["articles.prix_ht"];
                orderLinesArray.Add(orderLine);
            }
            return orderLinesArray;
        }
    }
}
