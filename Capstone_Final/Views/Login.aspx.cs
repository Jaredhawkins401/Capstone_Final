using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Helpers;
using Capstone_Final.Models;

namespace Capstone_Final.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LoggedIn"] = "TRUE";
            Users user = new Users();
            Database.SearchUser("jaredhawkins", out user);
            Session["CurrentUser"] = user;
             Response.Redirect("AJAXMain.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            /*
            string username = userNameBox.Text;
            string password = userPassBox.Text;
            Users user = new Users();
            string errors = string.Empty;


            Database.SearchUser(username, out user);
            if (Crypto.VerifyHashedPassword(user.Password, user.Salt + password))
            {
                if (user.PasswordResetFlag == true)
                {
                    Session["CurrentUser"] = user;
                    Response.Redirect("PasswordReset.aspx");
                }
                else
                {
                    Session["LoggedIn"] = "TRUE";
                    Session["CurrentUser"] = user;
                    Response.Redirect("~/Views/AJAXMain.aspx");
                }
            }
            else
            {
                errorBox.Text = errors;
            }
            */

            Response.Redirect("PasswordReset.aspx");
        }
    }

}