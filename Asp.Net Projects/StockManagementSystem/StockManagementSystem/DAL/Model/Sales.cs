using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    public class Sales
    {
        public int Id { get; private set; }
        public int ItemId { get; private set; }
        public string ItemName { get; private set; }
        public double Quantity { get; private set; }

        public Sales(int id, int itemId, string itemName, double quantity)
        {
            Id = id;
            ItemId = itemId;
            ItemName = itemName;
            Quantity = quantity;
        }
    }
}