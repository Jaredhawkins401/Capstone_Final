﻿using Capstone_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Capstone_Final.Views;

namespace Capstone_Final.Views
{
    public partial class TransactionTable : System.Web.UI.Page
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

                    DataSet ds = Database.SearchTransactions("transactionID", "0");

                    if (columnBox.DataMember.Length <= 0)
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
            
            DataSet ds = Database.SearchTransactions(searchBox.Text, columnBox.SelectedValue);
            
            transactionView.AutoGenerateColumns = false; 
            transactionView.DataSource = ds;
            transactionView.DataMember = ds.Tables[0].TableName;
            transactionView.DataBind();
        }
    }
}

