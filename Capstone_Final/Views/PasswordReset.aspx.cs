using Capstone_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone_Final.Views
{
    public partial class passReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("AJAXMain.aspx");
        }

        protected void PassConfirmButton_Click(object sender, EventArgs e)
        {
            /*
            string password = passwordBox.Text;
            string passwordConfirm = confirmBox.Text;
            Users user = (Users)Session["CurrentUser"];
            string errors = string.Empty;
            if (user != null)
            {
                if (password == passwordConfirm)
                {
                    errorBox.Text = Database.UpdatePassword(user, password);
                    user.PasswordResetFlag = false;
                    Response.Redirect("Login.aspx");
                }

            }
            else
                Response.Redirect("Login.aspx");
                */

        }
    }
}