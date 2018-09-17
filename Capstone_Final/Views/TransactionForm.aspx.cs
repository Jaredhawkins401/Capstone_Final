using Capstone_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone_Final.Views
{
    public partial class TransactionForm : System.Web.UI.Page
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


                if ((!IsPostBack) && (Request.QueryString["jobID"] != null || Request.QueryString["transactionID"] != null))
                {
                    if (Request.QueryString["transactionID"] != null)
                    {

                        createButton.Visible = false;
                        updateButton.Visible = true;
                        deleteButton.Visible = true;
                        string transactionID = Request.QueryString["transactionID"].ToString();

                        Transactions transaction = new Transactions();
                        string result = Database.LocateTransaction(Convert.ToInt32(transactionID), out transaction);

                        if (transaction != null)
                        {
                            transactionIDBox.Text = transactionID;
                            jobIDBox.Text = transaction.JobID.ToString();
                            userIDBox.Text = transaction.UserID.ToString();
                            paymentBox.Text = transaction.Payment.ToString();
                            originalCostBox.Text = transaction.OriginalJobCost.ToString();
                            newJobCostBox.Text = transaction.NewJobCost.ToString();
                        }
                    }
                    else if(Request.QueryString["jobID"] != null)
                    {
                        Jobs job = new Jobs();
                        feedbackText.Text = Database.LocateJob(Convert.ToInt32(Request.QueryString["jobID"]), out job);

                        Session["CurrentJob"] = job;
                    }
                }

                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];
            Jobs currentJob = (Jobs)Session["CurrentJob"];
            if (currentUser.Role == Roles.Admin)
            {
                Transactions transaction = new Transactions();

                transaction.JobID = currentJob.JobID;
                transaction.UserID = currentUser.UserID;
                transaction.Payment = Convert.ToDouble(paymentBox.Text);
                transaction.OriginalJobCost = Convert.ToDouble(originalCostBox.Text);
                transaction.NewJobCost = Convert.ToDouble(newJobCostBox.Text);
                

                if (!transaction.ErrorMessages.Contains("ERROR:"))
                    feedbackText.Text = Database.AddTransaction(transaction);
                else

                    feedbackText.Text = transaction.ErrorMessages;



            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];
            if (currentUser.Role == Roles.Admin)
            {
                Transactions transaction = new Transactions();

                transaction.TransactionID = Convert.ToInt32(transactionIDBox.Text);
                transaction.JobID = Convert.ToInt32(jobIDBox.Text);
                transaction.UserID = Convert.ToInt32(userIDBox.Text);
                transaction.Payment = Convert.ToDouble(paymentBox.Text);
                transaction.OriginalJobCost = Convert.ToDouble(originalCostBox.Text);
                transaction.NewJobCost = Convert.ToDouble(newJobCostBox.Text);

                if (!transaction.ErrorMessages.Contains("ERROR:"))
                    feedbackText.Text = Database.UpdateTransaction(transaction);

                else
                    feedbackText.Text = transaction.ErrorMessages;
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];

            if (currentUser.Role == Roles.Admin)
                feedbackText.Text = Database.DeleteTransaction(Convert.ToInt32(transactionIDBox.Text));
        }
    }
}