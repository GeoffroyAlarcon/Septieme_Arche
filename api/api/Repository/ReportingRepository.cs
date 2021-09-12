using api.models;
using api.septiemarche.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace api.septiemarche.Repository
{
    public class ReportingRepository : IReportingRepository
    {

        public MySqlConnector Db { get; }
        public ReportingRepository(MySqlConnector db)
        {
            Db = db;
        }


        public List<Item> Stockisempty()
        {
            Db.Connection.Open();
            List<Item> items = new List<Item>();
            using var cmd = Db.Connection.CreateCommand();
            string query = "select nom, id from articles where quantite = 0 and typesId = 1";
            cmd.CommandText = query;
            DbDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                Item item = new Item();
                item.Name = myReader["nom"].ToString();
                item.Id = (int) myReader["id"];
                items.Add(item);
            }
            Db.Connection.Close();
            return items;

        }
        public List<Item> TopTenItemMostSold()
        {
            Db.Connection.Open();
            List<Item> items = new List<Item>();
            using var cmd = Db.Connection.CreateCommand();
            string query = "select nom, id, nombreVendu from articles order by nombreVendu DESC LIMIT 10";
            cmd.CommandText = query;
            DbDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                Item item = new Item();
                item.Name = myReader["nom"].ToString();
                item.Id = (int)myReader["id"];
                item.NumberOfSales = (int)myReader["nombreVendu"];
                items.Add(item);
            }
            Db.Connection.Close();
            return items;

    }
        public List<Item> TopTenItemMostView()
        {
            Db.Connection.Open();
            List<Item> items = new List<Item>();
            using var cmd = Db.Connection.CreateCommand();
            string query = "select nom, id, nombreConsultation,nombreVendu from articles order by nombreConsultation DESC LIMIT 10";
            cmd.CommandText = query;
            DbDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read())
            {
                Item item = new Item();
                item.Name = myReader["nom"].ToString();
                item.Id = (int)myReader["id"];
                item.NumberOfClicks = (int)myReader["nombreConsultation"];
                item.NumberOfSales = (int)myReader["nombreVendu"];
                items.Add(item);
            }
            Db.Connection.Close();
            return items;

        }
    }
}
