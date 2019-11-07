using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class UserManager
    {
        UserGateway gateway= new UserGateway();

        public int Authenticated(string username, string password)
        {
            return gateway.Authenticated(username, password);
        }

        public void Logout(int id)
        {
            gateway.Logout(id);
        }

        public List<UserLog> GetUserLogs()
        {
            return gateway.GetUserLogs();
        }
    }
}