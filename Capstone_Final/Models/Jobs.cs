using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Final.Models
{
    public class Jobs
    {
        private int jobID;
        private int customerID;
        private string location;
        private DateTime startDate;
        private DateTime estimatedCompletionDate;
        private DateTime completionDate;
        private double estimatedJobCost;

        public int JobID
        {
            get
            {
                return jobID;
            }
            set
            {
                jobID = value;
            }
        }

        public int CustomerID
        {
            get
            {
                return customerID;
            }
            set
            {
                customerID = value;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        public DateTime EstimatedCompletionDate
        {
            get
            {
                return estimatedCompletionDate;
            }
            set
            {
                estimatedCompletionDate = value;
            }
        }

        public DateTime CompletionDate
        {
            get
            {
                return completionDate;
            }
            set
            {
                completionDate = value;
            }
        }
    }
}