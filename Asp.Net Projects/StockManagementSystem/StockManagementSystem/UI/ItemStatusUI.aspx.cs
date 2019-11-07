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
    public partial class ItemStatusUI : System.Web.UI.Page
    {
        ItemManager manager= new ItemManager();
        CategoryManager categoryManager = new CategoryManager();
        CompanyManager companyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoginUI.aspx");
            }
            
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

        public void Clear()
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

        public void PopulateGridView(List<ItemDetails> items)
        {
            itemGridView.DataSource = items;
            itemGridView.DataBind();
        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (categoryDropDownList.SelectedValue == "0" && companyDropDownList.SelectedValue == "0")
            {
                messageLebel.Text = "Please select the Company and/or Category first!";
                PopulateGridView(new List<ItemDetails>());
                return;
            }
            string companyName = companyDropDownList.SelectedItem.Text;
            string categoryName = categoryDropDownList.SelectedItem.Text;
            if (categoryDropDownList.SelectedValue != "0" && companyDropDownList.SelectedValue != "0")
            {
                
                List<ItemDetails> items= manager.ItemDetailsByCompanyAndCategory(companyName, categoryName);
                if (items.Count == 0)
                {
                    messageLebel.Text = "There's no item with " + categoryName + " Category and " + companyName +
                                        " Company!";
                }
                else
                {
                    messageLebel.Text = "Following items found with " + categoryName + " Category and " + companyName +
                                        " Company!";
                }
                PopulateGridView(items);
            }
            else if (categoryDropDownList.SelectedValue != "0")
            {
                List<ItemDetails> items = manager.ItemDetailsByCategory(categoryName);
                if (items.Count == 0)
                {
                    messageLebel.Text = "There's no item with " + categoryName + " Category";
                }
                else
                {
                    messageLebel.Text = "Following items found with " + categoryName + " Category";
                }
                PopulateGridView(items);
            }
            else if(companyDropDownList.SelectedValue!= "0")
            {
                List<ItemDetails> items = manager.ItemDetailsByCompany(companyName);
                if (items.Count == 0)
                {
                    messageLebel.Text = "There's no item with " + companyName +
                                        " Company!";
                }
                else
                {
                    messageLebel.Text = "Following items found with " + companyName +
                                        " Company!";
                }
                PopulateGridView(items);
            }
        }

        protected void itemGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}