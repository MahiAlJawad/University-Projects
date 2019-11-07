using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.DAL.Gateway
{
    public class UserGateway: Gateway
    {
        public int Authenticated(string username, string password)
        {
            Query = "SELECT * FROM Users WHERE Username= @username and Password= @password";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("username", username);
            Command.Parameters.AddWithValue("password", password);

            Reader = Command.ExecuteReader();

            int hasRow = 0;
            if (Reader.HasRows)
            {
                hasRow = 1;
            }

            Reader.Close();
            Connection.Close();
            int id = hasRow;
            if (hasRow== 1)
            {
                id=  StartSession(username);
            }
            
            return id;
        }

        public int StartSession(string username)
        {
            Connection.Open();
            Query = "INSERT INTO UserLog(Username, StartTime) VALUES(@username, SYSDATETIME())";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("username", username);
           

            Command.ExecuteNonQuery();

            Connection.Close();
            //now returning the Id of the last connection established
            Query = "SELECT * FROM UserLog";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();

            Reader = Command.ExecuteReader();
            int id= 0;
            while (Reader.Read())
            {
                id = (int)Reader["Id"];
            }


            Reader.Close();
            Connection.Close();
            return id;
        }

        public void Logout(int id)
        {
            Connection.Open();
            Query = "UPDATE UserLog SET EndTime= SYSDATETIME() WHERE Id= @id";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("id", id);
           

            Command.ExecuteNonQuery();

            Connection.Close();

        }

        public List<UserLog> GetUserLogs()
        {
            Query = "SELECT * FROM UserLog";

            Command = new SqlCommand(Query, Connection);

            Connection.Open();


            Reader = Command.ExecuteReader();

            List<UserLog> logs = new List<UserLog>();

            while (Reader.Read())
            {
                int id = (int) Reader["Id"];
                string username = (string) Reader["Username"];
                string startTime = Convert.ToDateTime(Reader["StartTime"]).ToString();
                string endTime;
               
                if (!DBNull.Value.Equals(Reader["EndTime"]))
                {
                    endTime = Convert.ToDateTime(Reader["EndTime"]).ToString();
                }
                else
                {
                    endTime = "";
                }
                logs.Add(new UserLog(id, username, startTime, endTime));
            }

            Reader.Close();
            Connection.Close();

            return logs;
        }
    }
}