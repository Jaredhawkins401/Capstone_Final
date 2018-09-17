using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone_Final
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "TRUE")
            {
                Response.Redirect("~/Views/AJAXMain.aspx");
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }
    }
}