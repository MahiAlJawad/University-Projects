using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    
    public class ItemManager
    {
        ItemGateway gateway= new ItemGateway();

        public string Save(Item item)
        {
            if (item.Name == "" || item.CategoryId == 0 || item.CompanyId == 0)
            {
                return "Required fields must be filled!";
            }
            int rowAffected = gateway.Save(item);
            if (rowAffected == -1) return "The item already exists!";
            if (rowAffected > 0) return "Item added successfully! :)";
            return "Sorry! The item couldn't be added! :(";
        }

        public Item Search(int id)
        {
            return gateway.Search(id);
        }
        public List<Item> GetItemsWithCompanyID(int selectedCompanyId)
        {
            return gateway.GetItemsWithCompanyID(selectedCompanyId);
        }

        public string StockIn(int id, double available, double quantity)
        {
            int rowAffected = gateway.StockIn(id, available+quantity);
            if (rowAffected > 0)
            {
                return "Quantity added to the selected item!";
            }
            return "Sorry! Failed adding quantity! :(";
        }

        public void StockOut(ItemWithCompany item)
        {
            int itemId = item.ItemId;
            Item oldItem = gateway.Search(itemId);
            double newAvailable = oldItem.Available - item.Quantity;
            gateway.StockOut(itemId, newAvailable);
        }

        public List<ItemDetails> AllItemDetails()
        {
            return gateway.AllItemDetails();
        }

        public List<ItemDetails> ItemDetailsByCompanyAndCategory(string companyName, string categoryName)
        {
            return gateway.ItemDetailsByCompanyAndCategory(companyName, categoryName);
        }

        public List<ItemDetails> ItemDetailsByCategory(string categoryName)
        {
           return gateway.ItemDetailsByCategory(categoryName);
        }

        public List<ItemDetails> ItemDetailsByCompany(string companyName)
        {
            return gateway.ItemDetailsByCompany(companyName);
        }
    }
}