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
    public partial class AddCatagoryUI : System.Web.UI.Page
    {
        CategoryManager manager= new CategoryManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateGridView();
        }

        public void PopulateGridView()
        {
            List<Category> catagories = manager.GetAllCategory();
            catagoryGridView.DataSource = catagories;
            catagoryGridView.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            Category aCatagory= new Category(nameTextBox.Text);
            if (saveButton.Text == "Update")
            {
                messageLabel.Text = manager.Update(ViewState["nameToBeUpdated"].ToString(), nameTextBox.Text);
                nameTextBox.Text = "";
                PopulateGridView();
                saveButton.Text = "Save";
            }
            else
            {
                messageLabel.Text = manager.Save(aCatagory);
                nameTextBox.Text = "";
                PopulateGridView();
            }
        }

        protected void catagoryGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("ondblclick", "__doPostBack('catagoryGridView','Select$" + e.Row.RowIndex + "');");
            }
        }

        protected void catagoryGridView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["nameToBeUpdated"] = catagoryGridView.SelectedDataKey.Value.ToString();
            nameTextBox.Text = ViewState["nameToBeUpdated"].ToString();
            saveButton.Text = "Update";
        }
    }
}