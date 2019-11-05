using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    public class ItemDetails
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CompanyName { get; private set; }
        public string CategoryName { get; private set; }
        public double Available { get; private set; }
        public double ReorderLevel { get; private set; }

        public ItemDetails(int id, string name, string companyName, string categoryName, double available, double reorderLevel)
        {
            Id = id;
            Name = name;
            CompanyName = companyName;
            CategoryName = categoryName;
            Available = available;
            ReorderLevel = reorderLevel;
        }
    }
}