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
    public partial class StockOutUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoginUI.aspx");
            }
            CompanyManager companyManager = new CompanyManager();
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
            PopulateGridView();
        }

        public void PopulateGridView()
        {
            List<ItemWithCompany> stockOutList = (List<ItemWithCompany>) ViewState["StockOutList"];
            stockOutGridView.DataSource = stockOutList;
            stockOutGridView.DataBind();
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

        protected void addButton_Click(object sender, EventArgs e)
        {
            
            if (companyDropDownList.SelectedValue == "0" || itemDropDownList.SelectedValue == "0" ||
                stockQuantityTextBox.Text == "")
            {
                messageLabel.Text = "Please fill all the required fields!";
                return;
            }

            List<ItemWithCompany> stockOutList = (List<ItemWithCompany>) ViewState["StockOutList"];
            double available = Convert.ToDouble(availableTextBox.Text);
            double quantity;

            if (!double.TryParse(stockQuantityTextBox.Text, out quantity) || quantity<=0 )
            {
                messageLabel.Text = "Non-positive quantity cannot be stocked out! :D";
                ClearFields();
                return;
            }
            quantity = Convert.ToDouble((stockQuantityTextBox.Text));
            if (quantity > available)
            {
                messageLabel.Text = "Stock Out Failed! :( Don't have sufficient quantity in the stock!";
            }
            else
            {
                int itemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                string itemName = itemDropDownList.SelectedItem.Text;
                bool found = false;
                if (stockOutList == null)
                {
                    stockOutList= new List<ItemWithCompany>();
                    stockOutList.Add(new ItemWithCompany(itemId, itemName, companyDropDownList.SelectedItem.Text, quantity));
                    messageLabel.Text = "";
                    ViewState["StockOutList"] = stockOutList;
                    ClearFields();
                    PopulateGridView();
                    return;
                }
                foreach (ItemWithCompany item in stockOutList)
                {
                    if (item.ItemName == itemName)
                    {
                        found = true;
                        if (item.Quantity + quantity > available)
                        {
                            messageLabel.Text = "Stock Out Failed! :( Don't have sufficient quantity in the stock!";
                            ClearFields();
                            return;
                        }
                        else
                        {
                            item.Quantity += quantity;
                        }
                        break;
                    }
                }
                if (found == false)
                {
                    stockOutList.Add(new ItemWithCompany(itemId, itemName, companyDropDownList.SelectedItem.Text, quantity));
                    messageLabel.Text = "";
                    
                }
            }
            ViewState["StockOutList"] = stockOutList;
            ClearFields();
            PopulateGridView();

        }

        protected void companyDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);

            ItemManager itemManager = new ItemManager();
            List<Item> items = itemManager.GetItemsWithCompanyID(selectedCompanyId);
            itemDropDownList.DataSource = items;
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataTextField = "Name";
            itemDropDownList.DataBind();
            itemDropDownList.Items.Insert(0, new ListItem("Select Item", "0"));
            messageLabel.Text = "";
            reorderLevelTextBox.Text = "";
            availableTextBox.Text = "";
            stockQuantityTextBox.Text = "";
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

        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<ItemWithCompany> stockOutList = (List<ItemWithCompany>) ViewState["StockOutList"];
            if (stockOutList == null)
            {
                messageLabel.Text = "No Items to stock out!";
                ClearFields();
                return;
            }
            ItemManager itemManager = new ItemManager();
            SalesManager salesManager= new SalesManager();
            foreach (ItemWithCompany item in stockOutList)
            {
                salesManager.Sell(item);
                itemManager.StockOut(item);
            }
            stockOutList.Clear();
            PopulateGridView();
            ClearFields();
            messageLabel.Text = "Selected Items sold and stocked out!";
            ViewState["StockOutList"] = null;
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {
            List<ItemWithCompany> stockOutList = (List<ItemWithCompany>)ViewState["StockOutList"];
            if (stockOutList == null)
            {
                messageLabel.Text = "No Items to stock out!";
                ClearFields();
                return;
            }
            ItemManager itemManager = new ItemManager();
            
            foreach (ItemWithCompany item in stockOutList)
            {
                itemManager.StockOut(item);
            }
            stockOutList.Clear();
            PopulateGridView();
            ClearFields();
            messageLabel.Text = "Selected Items stocked out!";
            ViewState["StockOutList"] = null;
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            List<ItemWithCompany> stockOutList = (List<ItemWithCompany>)ViewState["StockOutList"];
            if (stockOutList == null)
            {
                messageLabel.Text = "No Items to stock out!";
                ClearFields();
                return;
            }
            ItemManager itemManager = new ItemManager();

            foreach (ItemWithCompany item in stockOutList)
            {
                itemManager.StockOut(item);
            }
            stockOutList.Clear();
            PopulateGridView();
            ClearFields();
            messageLabel.Text = "Selected Items stocked out!";
            ViewState["StockOutList"] = null;
        }

       
    }
}