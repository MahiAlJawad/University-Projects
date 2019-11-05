using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class CompanyGateway: Gateway
    {
        public bool DoesExist(string name)
        {
            Query = "SELECT * FROM Company WHERE Name= @name";

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
        public int Save(Company aCompany)
        {
            if (DoesExist(aCompany.Name)) return -1;
            Connection.Open();
            Query = "INSERT INTO Company VALUES(@name)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", aCompany.Name);
            int rowAfffected = Command.ExecuteNonQuery();

            Connection.Close();

            return rowAfffected;
        }

        public List<Company> GetAllCompany()
        {
            Query = "SELECT * FROM Company";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Company> companies = new List<Company>();

            while (Reader.Read())
            {
                int id = (int)Reader["Id"];
                string name = Reader["Name"].ToString();
                Company company = new Company(name);
                company.Id = id;
                companies.Add(company);
            }

            Reader.Close();
            Connection.Close();

            return companies;
        }
    }
}