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
    public partial class UserForm : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "TRUE")
            {
                if (Session["CurrentUser"] != null)
                {
                    Users currentUser = (Users)Session["CurrentUser"];

                    //redirect users without permissions
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
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

                if ((!IsPostBack) && Request.QueryString["userID"] != null)
                {
                    Users user = new Users();
                    string userID = Request.QueryString["userID"].ToString();
                    userIDBox.Text = userID;
                    string errors = Database.LocateUser(Convert.ToInt32(userID), out user);

                    createButton.Visible = false;
                    updateButton.Visible = true;
                    deleteButton.Visible = true;

                    if (user.PasswordResetFlag == true)
                    {
                        passwordResetBox.Checked = true;
                    }

                    if (user != null)
                    {
                        accountNameBox.Text = user.AccountName;
                        fNameBox.Text = user.FirstName;
                        lNameBox.Text = user.LastName;
                        emailBox.Text = user.Email;
                        roleBox.Text = user.Role.ToString();
                    }


                }
            }
            else
            {
                Response.Redirect("~/Views/Login.aspx");
            } 
        }
        /*
         *     private int userID;
        private string firstName;
        private string lastName;
        private string accountName;
        private string email;
        private string password;
        private string salt;
        private int role;
        private DateTime creationDate;
        private bool passwordResetFlag;
        private string errorMessages;
         * */

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];
            Users user = new Users();

            if(currentUser.Role == Roles.Admin)
            {
                user.FirstName = fNameBox.Text ;
                user.LastName = lNameBox.Text ;
                user.AccountName = accountNameBox.Text;
                user.Email = emailBox.Text ;
                user.Role = int.Parse(roleBox.Text);

                if (!user.ErrorMessages.Contains("ERROR:"))
                {
                    feedbackText.Text = Database.AddUser(user);
                }
                else
                {
                    feedbackText.Text = user.ErrorMessages;
                }
            }

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];
            Users user = new Users();

            if (currentUser.Role == Roles.Admin)
            {
                user.UserID = Convert.ToInt32(userIDBox.Text);
                user.FirstName = fNameBox.Text;
                user.LastName = lNameBox.Text;
                user.AccountName = accountNameBox.Text;
                user.Email = emailBox.Text;
                user.Role = int.Parse(roleBox.Text);

                if (!user.ErrorMessages.Contains("ERROR:"))
                    feedbackText.Text = Database.UpdateUser(user);
                else
                    feedbackText.Text = user.ErrorMessages;
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];

            if (currentUser.Role == Roles.Admin)
                feedbackText.Text = Database.DeleteUser(Convert.ToInt32(userIDBox.Text));
        }
    }
}