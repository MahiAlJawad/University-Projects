using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    
    public class SalesManager
    {
        SalesGateway gateway= new SalesGateway();

        public void Sell(ItemWithCompany item)
        {
            gateway.Sell(item);
        }

        public List<Sales> GetSalesByDate(string fromDate, string toDate)
        {
            return gateway.GetSalesByDate(fromDate, toDate);
        }
    }
}