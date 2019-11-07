using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementSystem.BLL;

namespace StockManagementSystem.UI
{
    public partial class LoginUI : System.Web.UI.Page
    {
        UserManager manager= new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["user"] = null;
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            int id= manager.Authenticated(username, password);
            if (id>0)
            {
                Session["user"] = id;
                Response.Redirect("StockInUI.aspx");
            }
            else
            {
                messageLabel.Text = "Invalid Username or Password!";
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";
            }
        }
    }
}