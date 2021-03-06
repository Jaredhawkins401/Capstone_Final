﻿using Capstone_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone_Final.Views
{
    public partial class CustomersTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "TRUE")
            {
                if (Session["CurrentUser"] != null)
                {
                    Users currentUser = (Users)Session["CurrentUser"];
                    DataSet ds = Database.SearchCustomers("customerID", "0");

                    if (columnBox.DataMember.Length <= 0)
                    {
                        foreach (DataColumn column in ds.Tables[0].Columns)
                        {
                            columnBox.Items.Add(new ListItem(column.ToString(), column.ToString()));
                        }
                    }

                    switch (currentUser.Role)
                    {

                        //admin
                        case 1:
                            break;

                        //accountant
                        case 2:
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

                }
            }
            else
                Response.Redirect("Login.aspx");
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            DataSet ds = Database.SearchCustomers(searchBox.Text, columnBox.SelectedValue);

            customerView.AutoGenerateColumns = false;
            customerView.DataSource = ds;
            customerView.DataMember = ds.Tables[0].TableName;
            customerView.DataBind();
        }
    }
}