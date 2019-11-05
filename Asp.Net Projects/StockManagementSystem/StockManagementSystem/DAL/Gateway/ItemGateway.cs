using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class ItemGateway: Gateway
    {
        public bool DoesExist(string name)
        {
            Query = "SELECT * FROM Item WHERE Name= @name";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", name);

            Reader = Command.ExecuteReader();

            bool hasRow = false;
            if (Reader.HasRows)
            {
                hasRow = true;
            }

            Reader.Close();
            Connection.Close();
            return hasRow;
        }

        public Item Search(int id)
        {
            Query = "SELECT * FROM Item WHERE Id= @Id";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Id", id);

            Reader = Command.ExecuteReader();
            Item item = null;
            while (Reader.Read())
            {
                int Id = (int)Reader["Id"];
                string name = Reader["Name"].ToString();
                int companyId = (int)Reader["CompanyId"];
                int categoryId = (int)Reader["CategoryId"];
                double reorderLevel = (double)Reader["ReorderLevel"];
                double available = (double)Reader["Available"];
                item = new Item(name, companyId, categoryId, reorderLevel);
                item.Available = available;
                item.Id = Id;
            }

        
            Reader.Close();
            Connection.Close();
            return item;
        }
        public int Save(Item item)
        {
            if (DoesExist(item.Name)) return -1;
            Connection.Open();
            Query = "INSERT INTO Item VALUES(@name, @companyId, @categoryId, @reorderLevel, @available)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", item.Name);
            Command.Parameters.AddWithValue("companyId", item.CompanyId);
            Command.Parameters.AddWithValue("categoryId", item.CategoryId);
            Command.Parameters.AddWithValue("reorderLevel", item.ReorderLevel);
            Command.Parameters.AddWithValue("available", item.Available);
            int rowAfffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAfffected;
        }

        public List<Item> GetItemsWithCompanyID(int selectedCompanyId)
        {
            Query = "SELECT * FROM Item WHERE CompanyId= @selectedCompanyId";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("selectedCompanyId", selectedCompanyId);

            Reader = Command.ExecuteReader();

            List<Item> items = new List<Item>();

            while (Reader.Read())
            {
                int id = (int)Reader["Id"];
                string name = Reader["Name"].ToString();
                int companyId = (int) Reader["CompanyId"];
                int categoryId = (int) Reader["CategoryId"];
                double reorderLevel = (double) Reader["ReorderLevel"];
                double available = (double) Reader["Available"];
                Item item= new Item(name, companyId, categoryId, reorderLevel);
                item.Available = available;
                item.Id = id;
                items.Add(item);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }

        public int StockIn(int id, double newAvailable)
        {
            
            Connection.Open();
            Query = "UPDATE Item SET Available= @newAvailable WHERE Id= @id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("newAvailable", newAvailable);
            Command.Parameters.AddWithValue("id", id);

            int rowAfffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAfffected;
        }

        public void StockOut(int id, double newAvailable)
        {
            Connection.Open();
            Query = "UPDATE Item SET Available= @newAvailable WHERE Id= @id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("newAvailable", newAvailable);
            Command.Parameters.AddWithValue("id", id);

            int rowAfffected = Command.ExecuteNonQuery();

            Connection.Close();
        }

        public List<ItemDetails> AllItemDetails()
        {
            Query = "SELECT * FROM ItemDetails";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<ItemDetails> items = new List<ItemDetails>();

            while (Reader.Read())
            {
                int id = (int)Reader["Id"];
                string name = Reader["Name"].ToString();
                string companyName = (string) Reader["CompanyName"];
                string categoryName =  (string) Reader["CategoryName"];
                double reorderLevel = (double)Reader["ReorderLevel"];
                double available = (double)Reader["Available"];
                ItemDetails item= new ItemDetails(id, name, companyName, categoryName, 
                    available, reorderLevel);
                
                items.Add(item);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }

        public List<ItemDetails> ItemDetailsByCompanyAndCategory(string companyName, string categoryName)
        {
            Query = "SELECT * FROM ItemDetails WHERE CompanyName= @companyName and CategoryName= @categoryName";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("companyName", companyName);
            Command.Parameters.AddWithValue("categoryName", categoryName);
            Reader = Command.ExecuteReader();

            List<ItemDetails> items = new List<ItemDetails>();

            while (Reader.Read())
            {
                int id = (int)Reader["Id"];
                string name = Reader["Name"].ToString();
                string comName = (string)Reader["CompanyName"];
                string catName = (string)Reader["CategoryName"];
                double reorderLevel = (double)Reader["ReorderLevel"];
                double available = (double)Reader["Available"];
                ItemDetails item = new ItemDetails(id, name, comName, catName,
                    available, reorderLevel);

                items.Add(item);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }

        public List<ItemDetails> ItemDetailsByCategory(string categoryName)
        {
            Query = "SELECT * FROM ItemDetails WHERE CategoryName= @categoryName";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("categoryName", categoryName);
            Reader = Command.ExecuteReader();

            List<ItemDetails> items = new List<ItemDetails>();

            while (Reader.Read())
            {
                int id = (int)Reader["Id"];
                string name = Reader["Name"].ToString();
                string comName = (string)Reader["CompanyName"];
                string catName = (string)Reader["CategoryName"];
                double reorderLevel = (double)Reader["ReorderLevel"];
                double available = (double)Reader["Available"];
                ItemDetails item = new ItemDetails(id, name, comName, catName,
                    available, reorderLevel);

                items.Add(item);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }

        public List<ItemDetails> ItemDetailsByCompany(string companyName)
        {
            Query = "SELECT * FROM ItemDetails WHERE CompanyName= @companyName";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("companyName", companyName);
            Reader = Command.ExecuteReader();

            List<ItemDetails> items = new List<ItemDetails>();

            while (Reader.Read())
            {
                int id = (int)Reader["Id"];
                string name = Reader["Name"].ToString();
                string comName = (string)Reader["CompanyName"];
                string catName = (string)Reader["CategoryName"];
                double reorderLevel = (double)Reader["ReorderLevel"];
                double available = (double)Reader["Available"];
                ItemDetails item = new ItemDetails(id, name, comName, catName,
                    available, reorderLevel);

                items.Add(item);
            }

            Reader.Close();
            Connection.Close();

            return items;
        }
    }
}