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
    public partial class ViewSalesUI : System.Web.UI.Page
    {
        SalesManager manager= new SalesManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoginUI.aspx");
            }
        }

        public void PopulateGridView(List<Sales> items)
        {
            
            salesGridView.DataSource = items;
            salesGridView.DataBind();

        }
        protected void searchButton_Click(object sender, EventArgs e)
        {
            string fromDate = fromDateTextBox.Text;
            string toDate = toDateTextBox.Text;
            if (fromDate == "" || toDate == "")
            {
                messageLabel.Text = "Please select Date first!";
                fromDateTextBox.Text = "";
                toDateTextBox.Text = "";
                PopulateGridView(new List<Sales>());
                return;
            }
            if (DateTime.Parse(toDate) < DateTime.Parse(fromDate))
            {
                messageLabel.Text = "Invalid Search! To Date must be greater or equals to the from Date!";
                fromDateTextBox.Text = "";
                toDateTextBox.Text = "";
                PopulateGridView(new List<Sales>());
                return;
            }
            List<Sales> items = manager.GetSalesByDate(fromDate, toDate);
            if (items.Count == 0)
            {
                messageLabel.Text = "No Sales information found!";
                fromDateTextBox.Text = "";
                toDateTextBox.Text = "";
                PopulateGridView(items);
            }
            else
            {
                messageLabel.Text = "The following sales record found";
                PopulateGridView(items);
                fromDateTextBox.Text = "";
                toDateTextBox.Text = "";
            }
        }

        protected void salesGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}