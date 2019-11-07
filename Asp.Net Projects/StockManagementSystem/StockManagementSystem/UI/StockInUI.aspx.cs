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
    public partial class StockInUI : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoginUI.aspx");
            }
            CompanyManager companyManager= new CompanyManager();
            if (!IsPostBack)
            {
                List<Company> companies = companyManager.GetAllCompany();
                companyDropDownList.DataSource = companies;
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataBind();
                companyDropDownList.Items.Insert(0, new ListItem("Select Company", "0"));
                itemDropDownList.Items.Insert(0, new ListItem("Select Company First", "0"));
                messageLabel.Text = "";
            }
        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            
            ItemManager itemManager= new ItemManager();
            List<Item> items = itemManager.GetItemsWithCompanyID(selectedCompanyId);
            itemDropDownList.DataSource = items;
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataTextField = "Name";
            itemDropDownList.DataBind();
            itemDropDownList.Items.Insert(0, new ListItem("Select Item", "0"));
            messageLabel.Text = "";
            stockQuantityTextBox.Text = "";
            availableTextBox.Text = "";
            reorderLevelTextBox.Text = "";
        }

        public void ClearFields()
        {
            companyDropDownList.ClearSelection();
            itemDropDownList.ClearSelection();
            reorderLevelTextBox.Text = "";
            availableTextBox.Text = "";
            stockQuantityTextBox.Text = "";

            List<Item> items = new List<Item>();
            itemDropDownList.DataSource = items;
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataTextField = "Name";
            itemDropDownList.DataBind();
            itemDropDownList.Items.Insert(0, new ListItem("Select Company First", "0"));

        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            ItemManager itemManager= new ItemManager();
            if (companyDropDownList.SelectedValue == "0" || itemDropDownList.SelectedValue == "0" ||
                stockQuantityTextBox.Text == "")
            {
                messageLabel.Text = "Please fill all the required fields!";
                return;
            }
            double available = Convert.ToInt32(availableTextBox.Text);
            double quantity = Convert.ToDouble(stockQuantityTextBox.Text);
            if (quantity <= 0)
            {
                messageLabel.Text = "Non-Positive quantity cannot be stocked in! :D";
                ClearFields();
                return;
            }
            int id = Convert.ToInt32(itemDropDownList.SelectedValue);
            messageLabel.Text = itemManager.StockIn(id, available, quantity);
            ClearFields();
           
        }

        protected void itemDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
            if (selectedItemId == 0)
            {
                reorderLevelTextBox.Text = "";
                availableTextBox.Text = "";
                return;
            }
            ItemManager itemManager = new ItemManager();
            Item item = itemManager.Search(selectedItemId);
            reorderLevelTextBox.Text = item.ReorderLevel.ToString();
            availableTextBox.Text = item.Available.ToString();
            messageLabel.Text = "";
        }
    }
}