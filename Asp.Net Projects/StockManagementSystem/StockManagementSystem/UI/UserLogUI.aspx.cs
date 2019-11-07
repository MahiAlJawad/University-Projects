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
    public partial class UserLogUI : System.Web.UI.Page
    {
        UserManager manager= new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("LoginUI.aspx");
            }
            PopulateGridView();
        }

        public void PopulateGridView()
        {
            List<UserLog> logs = manager.GetUserLogs();
            sessionGridView.DataSource = logs;
            sessionGridView.DataBind();
        }

        protected void sessionGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void sessionGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.TableSection = TableRowSection.TableHeader;
            }
        }
    }
}