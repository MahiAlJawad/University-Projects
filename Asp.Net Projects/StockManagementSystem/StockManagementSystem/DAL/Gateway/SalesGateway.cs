using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class SalesGateway: Gateway
    {
        public void Sell(ItemWithCompany item)
        {
            Connection.Open();
            Query = "INSERT INTO Sales VALUES(CONVERT (date, SYSDATETIME()), @itemId, @itemName, @quantity)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("itemId", item.ItemId);
            Command.Parameters.AddWithValue("itemName", item.ItemName);
            Command.Parameters.AddWithValue("quantity", item.Quantity);
           
            Command.ExecuteNonQuery();

            Connection.Close();
        }

        public List<Sales> GetSalesByDate(string fromDate, string toDate)
        {
            Query = "SELECT * FROM Sales WHERE Date>= @fromDate and Date<= @toDate";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("fromDate", fromDate);
            Command.Parameters.AddWithValue("toDate", toDate);

            Reader = Command.ExecuteReader();

            List<Sales> items = new List<Sales>();

            while (Reader.Read())
            {
                int id = (int) Reader["Id"];
                int itemId = (int) Reader["ItemId"];
                string itemName = (string) Reader["ItemName"];
                double quantity = (double) Reader["Quantity"];

                Sales item= new Sales(id,itemId, itemName, quantity);
                items.Add(item);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }
    }
}