using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public int CompanyId { get; private set; }
        public int CategoryId { get; private set; }
        public double ReorderLevel { get; private set; }
        public double Available { get; set; }

        public Item(string name, int companyId, int categoryId, double reorderLevel): this()
        {
            Name = name;
            CompanyId = companyId;
            CategoryId = categoryId;
            ReorderLevel = reorderLevel;
        }

        public Item()
        {
            Available = 0;
        }
    }
}