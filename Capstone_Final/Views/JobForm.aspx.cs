using Capstone_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone_Final.Views
{
    public partial class JobForm : System.Web.UI.Page
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
                }


                if ((!IsPostBack) && Request.QueryString["jobID"] != null)
                {

                    createButton.Visible = false;
                    updateButton.Visible = true;
                    deleteButton.Visible = true;
                    string jobID = Request.QueryString["jobID"].ToString();
                    jobIDBox.Text = jobID;
                    Jobs job = new Jobs();
                    string result = Database.LocateJob(Convert.ToInt32(jobID), out job);

                    while (job != null)
                    {
                        jobIDBox.Text = job.JobID.ToString();
                        customerIDBox.Text = job.CustomerID.ToString();
                        startDatePicker.SelectedDate = job.StartDate;
                        estimatedCompletionDatePicker.SelectedDate = job.EstimatedCompletionDate;
                        completionDatePicker.SelectedDate = job.CompletionDate;
                        estimatedCostBox.Text = job.EstimatedJobCost.ToString();
                        completedCostBox.Text = job.CompletedJobCost.ToString();
                        streetBox.Text = job.Street;
                        cityBox.Text = job.City;
                        stateBox.Text = job.State;
                        zipBox.Text = job.Zip;

                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

            }
        }
        /*         private int jobID;
private int customerID;
private string street;
private string city;
private string state;
private string zip;
private DateTime startDate;
private DateTime estimatedCompletionDate;
private DateTime completionDate;
private double estimatedJobCost;
private double completedJobCost;*/
        protected void CreateButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];
            if (currentUser.Role == Roles.Admin)
            {
                Jobs job = new Jobs();

                job.StartDate = startDatePicker.SelectedDate;
                job.EstimatedCompletionDate = estimatedCompletionDatePicker.SelectedDate;
                job.CompletionDate = completionDatePicker.SelectedDate;
                job.Street = streetBox.Text;
                job.City = cityBox.Text;
                job.State = stateBox.Text;
                job.Zip = zipBox.Text;
                job.EstimatedJobCost = double.Parse(estimatedCostBox.Text);
                job.CompletedJobCost = double.Parse(completedCostBox.Text);

                if (!job.ErrorMessages.Contains("ERROR:"))
                {
                    feedbackText.Text = Database.AddJob(job);
                }
                else
                {
                    feedbackText.Text = job.ErrorMessages;
                }


            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];
            if (currentUser.Role == Roles.Admin)
            {
                Jobs job = new Jobs();

                job.JobID = Convert.ToInt32(jobIDBox.Text);
                job.StartDate = startDatePicker.SelectedDate;
                job.EstimatedCompletionDate = estimatedCompletionDatePicker.SelectedDate;
                job.CompletionDate = completionDatePicker.SelectedDate;
                job.Street = streetBox.Text;
                job.City = cityBox.Text;
                job.State = stateBox.Text;
                job.Zip = zipBox.Text;
                job.EstimatedJobCost = double.Parse(estimatedCostBox.Text);
                job.CompletedJobCost = double.Parse(completedCostBox.Text);

                if (!job.ErrorMessages.Contains("ERROR:"))
                    feedbackText.Text = Database.UpdateJob(job);
                else
                    feedbackText.Text = job.ErrorMessages;
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Users currentUser = (Users)Session["CurrentUser"];

            if (currentUser.Role == Roles.Admin)
                feedbackText.Text = Database.DeleteJob(Convert.ToInt32(jobIDBox.Text));
        }
    }
}