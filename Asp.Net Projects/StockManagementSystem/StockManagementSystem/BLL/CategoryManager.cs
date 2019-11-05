using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class CategoryManager
    {
        CategoryGateway gateway= new CategoryGateway();
        public string Save(Category aCatagory)
        {
            if (aCatagory.Name == "") return "Category name cannot be empty!";
            int rowAffected = gateway.Save(aCatagory);
            if (rowAffected == -1) return "This Category name already exists!";
            if (rowAffected > 0)
            {
                return "Category added successfully! :)";
            }
            else
            {
                return "Sorry! Couldn't added category! :(";
            }
        }

        public List<Category> GetAllCategory()
        {
            return gateway.GetAllCategory();
        }

        public string Update(string prevName, string newName)
        {
            if (newName == "") return "Category name cannot be empty!";
            int rowAffected = gateway.Update(prevName, newName);
            if (rowAffected == -1) return "This Category name already exists!";
            if (rowAffected > 0)
            {
                return "Category updated successfully! :)";
            }
            else
            {
                return "Sorry! Couldn't updated category! :(";
            }
        }
    }
}