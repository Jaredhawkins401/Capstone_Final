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
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = string.Empty;
            string password = string.Empty;

            password = Request.Form["userPassBox"];
            username = Request.Form["userNameBox"];
            Users user = new Users();
            string errors = string.Empty;

            Database.SearchUser(username, out user);

            if (Crypto.VerifyHashedPassword(user.Password, user.Salt + password))
            {
                Session["LoggedIn"] = true;
                Session["CurrentUser"] = user;
                Response.Redirect("~/Views/AJAXMain.aspx");
            }
            else
            {
                errorBox.Text = errors;
            }

        }
    }

}