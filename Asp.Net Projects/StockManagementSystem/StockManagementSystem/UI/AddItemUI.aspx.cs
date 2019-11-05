using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;
using StockManagementSystem.DAL.Gateway;
using StockManagementSystem.DAL.Model;

namespace StockManagementSystem.UI
{
    public partial class AddItemUI : System.Web.UI.Page
    {
        ItemManager manager= new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoryManager categoryManager= new CategoryManager();
            CompanyManager companyManager= new CompanyManager();
            
            if (!IsPostBack)
            {
                List<Category> categories = categoryManager.GetAllCategory();
                categoryDropDownList.DataSource = categories;
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataTextField = "Name";
                categoryDropDownList.DataBind();
                categoryDropDownList.Items.Insert(0, new ListItem("Select Category", "0"));

                List<Company> companies = companyManager.GetAllCompany();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("Select Company", "0"));
            }
        }

        public void ClearFields()
        {
            nameTextBox.Text = "";
            reorderLevelTextBox.Text = "";
            categoryDropDownList.ClearSelection();
            companyDropDownList.ClearSelection();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            double reorderLevel;
            if (reorderLevelTextBox.Text == "") reorderLevel = 0;
            else reorderLevel = Convert.ToDouble(reorderLevelTextBox.Text);
            Item item = new Item(nameTextBox.Text, Convert.ToInt32(companyDropDownList.SelectedValue), Convert.ToInt32(categoryDropDownList.SelectedValue), reorderLevel);
            messageLabel.Text = manager.Save(item);
            ClearFields();
        }
    }
}