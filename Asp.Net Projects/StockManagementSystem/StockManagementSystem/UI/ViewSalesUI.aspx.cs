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
    }
}