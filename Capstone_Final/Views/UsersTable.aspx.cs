using Capstone_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone_Final.Views
{
    public partial class UsersTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "TRUE")
            {
                if (Session["CurrentUser"] != null)
                {
                    Users currentUser = (Users)Session["CurrentUser"];

                    switch (currentUser.Role)
                    {

                        //admin
                        case 1:
                            break;

                        //accountant
                        case 2:
                            Response.Redirect("AJAXMain.aspx");
                            break;

                        //contractor
                        case 3:
                            Response.Redirect("AJAXMain.aspx");
                            break;

                        //general
                        case 4:
                            Response.Redirect("AJAXMain.aspx");
                            break;
                    }
                    DataSet ds = Database.SearchUsers("userID", "0");

                    if (columnBox.Items.Count <= 0)
                    {
                        foreach (DataColumn column in ds.Tables[0].Columns)
                        {
                            columnBox.Items.Add(new ListItem(column.ToString(), column.ToString()));
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            DataSet ds = Database.SearchUser(searchBox.Text, columnBox.SelectedValue);

            userView.AutoGenerateColumns = false;
            userView.DataSource = ds;
            userView.DataMember = ds.Tables[0].TableName;
            userView.DataBind();
        }
    }
}