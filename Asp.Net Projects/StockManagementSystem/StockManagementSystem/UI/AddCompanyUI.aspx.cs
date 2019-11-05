using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.UI
{
    public partial class AddCompanyUI : System.Web.UI.Page
    {
        CompanyManager manager= new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        public void PopulateGridView()
        {
            List<Company> companies = manager.GetAllCompany();
            companyGridView.DataSource = companies;
            companyGridView.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Company aCompany= new Company(nameTextBox.Text);
            messageLabel.Text = manager.Save(aCompany);
            nameTextBox.Text = "";
            PopulateGridView();
        }
    }
}