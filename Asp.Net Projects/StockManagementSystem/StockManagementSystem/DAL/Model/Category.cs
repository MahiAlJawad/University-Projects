using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace StockManagementSystem.DAL.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; private set; }

        public Category(string name)
        {
            Name = name;
        }
    }
}