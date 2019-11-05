using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.BLL
{
    public class CompanyManager
    {
        CompanyGateway gateway=new CompanyGateway();

        public string Save(Company aCompany)
        {
            if (aCompany.Name == "") return "Company name cannot be empty!";

            int rowAffected = gateway.Save(aCompany);
            if (rowAffected == -1) return "This Company name already exists!";
            if (rowAffected > 0)
            {
                return "Company added successfully! :)";
            }
            else
            {
                return "Sorry! Couldn't added Company! :(";
            }
        }

        public List<Company> GetAllCompany()
        {
            return gateway.GetAllCompany();
        }
    }
}