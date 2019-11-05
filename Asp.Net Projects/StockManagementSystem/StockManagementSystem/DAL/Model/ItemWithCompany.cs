using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    [Serializable]
    public class ItemWithCompany
    {
        public int ItemId { get; private set; }
        public string ItemName { get; private set; }
        public string CompanyName { get; private set; }
        public double Quantity { get;  set; }

        public ItemWithCompany(int itemId, string itemName, string companyName, double quantity)
        {
            ItemId = itemId;
            ItemName = itemName;
            CompanyName = companyName;
            Quantity = quantity;
        }
    }
}