using Capstone_Final.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone_Final.Views
{
    public partial class CustomerForm : System.Web.UI.Page
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

                    if ((!IsPostBack) && Request.QueryString["customerID"] != null)
                    {

                        createButton.Visible = false;
                        updateButton.Visible = true;
                        deleteButton.Visible = true;
                        string customerID = Request.QueryString["customerID"].ToString();
                        customerIDBox.Text = customerID;


                        Customers customer = new Customers();
                        string result = Database.LocateCustomer(Convert.ToInt32(customerID), out customer);

                        if (customer != null)
                        {
                            customerIDBox.Text = customer.CustomerID.ToString();
                            fNameBox.Text = customer.FirstName;
                            lNameBox.Text = customer.LastName;
                            streetBox.Text = customer.Street;
                            cityBox.Text = customer.City;
                            stateBox.Text = customer.State;
                            zipBox.Text = customer.Zip;
                            emailBox.Text = customer.Email;
                        }
                    }
                }
            }
            else
                Response.Redirect("LoginForm.aspx");
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];
            if (currentUser.Role == Roles.Admin)
            {
                Customers customer = new Customers();

                customer.FirstName = fNameBox.Text;
                customer.LastName = lNameBox.Text;
                customer.Street = streetBox.Text;
                customer.City = cityBox.Text;
                customer.State = stateBox.Text;
                customer.Zip = zipBox.Text ;
                customer.Email = emailBox.Text ;

                if(!customer.ErrorMessages.Contains("ERROR:"))
                {
                    feedbackText.Text = Database.AddCustomer(customer);
                }
                else
                {
                    feedbackText.Text = customer.ErrorMessages;
                }
                

            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];
            if (currentUser.Role == Roles.Admin)
            {
                Customers customer = new Customers();

                customer.FirstName = fNameBox.Text;
                customer.LastName = lNameBox.Text;
                customer.Street = streetBox.Text;
                customer.City = cityBox.Text;
                customer.State = stateBox.Text;
                customer.Zip = zipBox.Text;
                customer.Email = emailBox.Text;
                customer.CustomerID = Convert.ToInt32(customerIDBox);

                feedbackText.Text = Database.UpdateCustomer(customer);

            } 
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];

            if (currentUser.Role == Roles.Admin)
                feedbackText.Text = Database.DeleteCustomer(Convert.ToInt32(customerIDBox.Text));
        }
    }
}