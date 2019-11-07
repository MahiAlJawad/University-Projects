using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;

namespace StockManagementSystem.UI
{
    public partial class LogoutUI : System.Web.UI.Page
    {
        UserManager manager= new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = (int) Session["user"];
            manager.Logout(id);
            Session["user"] = null;
            Response.Redirect("LoginUI.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}