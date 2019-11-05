using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class CategoryGateway: Gateway
    {
        public bool DoesExist(string name)
        {
            Query = "SELECT * FROM Category WHERE Name= @name";

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
        public int Save(Category aCategory)
        {
            if (DoesExist(aCategory.Name)) return -1;

            Connection.Open();
            Query = "INSERT INTO Category VALUES(@name)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", aCategory.Name);
            int rowAfffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAfffected;
        }

        public List<Category> GetAllCategory()
        {
            Query = "SELECT * FROM Category";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Category> categories = new List<Category>();

            while (Reader.Read())
            {
                int id = (int)Reader["Id"];
                string name = Reader["Name"].ToString();
                Category category= new Category(name);
                category.Id = id;
                categories.Add(category);
            }

            Reader.Close();
            Connection.Close();

            return categories;
        }

        public int Update(string prevName, string newName)
        {
            if (DoesExist(newName)) return -1;
            Connection.Open();
            Query = "UPDATE Category SET Name= @nName WHERE Name= @pName";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("nName", newName);
            Command.Parameters.AddWithValue("pName", prevName);

            int rowAfffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAfffected;
        }

    }
}