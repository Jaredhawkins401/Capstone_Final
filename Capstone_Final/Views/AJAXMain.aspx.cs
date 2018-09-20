using Capstone_Final.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Capstone_Final.Views
{
    public partial class AJAXMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null && Session["LoggedIn"].ToString() == "TRUE")
            {

                if (Session["CurrentUser"] != null)
                {
                    Users currentUser = (Users)Session["CurrentUser"];

                    DataSet ds = Database.GetAllJobs();
                    var start = DateTime.Now;
                    var end = DateTime.Now.AddMinutes(1);
                    var total = (end - start).TotalSeconds;

                    double estTotal = 0.0;
                    double actualTotal = 0.0;
                    double estJobCost = 0.0;
                    double jobCost = 0.0;
                    int count = 0;

                    if (ds != null)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                            estJobCost += (double)row["estimatedJobCost"];
                            jobCost += (double)row["completedJobCost"];
                            DateTime startDate = DateTime.Parse(row["startDate"].ToString());
                            DateTime estimatedDate = DateTime.Parse(row["estimatedCompletionDate"].ToString());
                            DateTime completedDate = DateTime.Parse(row["completionDate"].ToString());



                            estTotal += (estimatedDate - startDate).TotalSeconds;
                            actualTotal += (completedDate - startDate).TotalSeconds;
                            count++;


                        }

                        double costPercentage = (actualTotal - estTotal) / count * 100 / actualTotal;
                        double datePercentage = (jobCost - estJobCost) / count * 100 / jobCost;
                        costPercentage = Math.Truncate(costPercentage);
                        datePercentage = Math.Truncate(datePercentage);

                        int personTotal = Database.UsersLast60Days();

                        statTextBox.Text = string.Format("Our jobs are completed {0}% longer than our estimate.", datePercentage.ToString());
                        jobPercent.Text = string.Format("Our jobs are costing {0}% more than our initial estimates.", costPercentage.ToString());
                        customersTotal.Text = string.Format("We have received {0} new customer inquiries in the last 60 days.", personTotal.ToString());

                        stat1.Text = string.Format("{0}%", datePercentage.ToString());
                        stat2.Text = string.Format("{0}%", costPercentage.ToString());
                        stat3.Text = personTotal.ToString();

                        if (personTotal <= 4 || datePercentage <= 30 || costPercentage <= 30)
                        {
                            stat1.CssClass = "green";
                            stat2.CssClass = "green";
                            stat3.CssClass = "red";
                        }
                        else if (personTotal > 4 && personTotal < 8 || datePercentage > 30 && datePercentage < 75 || costPercentage <= 30 && costPercentage < 75)
                        {
                            stat1.CssClass = "yellow";
                            stat2.CssClass = "yellow";
                            stat3.CssClass = "yellow";
                        }
                        else if (personTotal > 8 || datePercentage > 75 || costPercentage > 75)
                        {
                            stat1.CssClass = "red";
                            stat2.CssClass = "red";
                            stat3.CssClass = "green";
                        }
                    }


                }
                else
                    Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}