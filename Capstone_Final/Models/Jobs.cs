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
        private string street;
        private string city;
        private string state;
        private string zip;
        private DateTime startDate;
        private DateTime estimatedCompletionDate;
        private DateTime completionDate;
        private double estimatedJobCost;
        private double completedJobCost;
        private string errorMessages;

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

        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                if (GeneralTools.NotEmptyOrNull(value))
                    street = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if (GeneralTools.NotEmptyOrNull(value))
                    city = value;
            }
        }

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                if (GeneralTools.NotEmptyOrNull(value) && GeneralTools.isState(value))
                    state = value;
                else
                    errorMessages += "\n ERROR: State is incorrect, try again";
            }
        }

        public string Zip
        {
            get
            {
                return zip;
            }
            set
            {
                if (GeneralTools.NotEmptyOrNull(value) && GeneralTools.isZip(value))
                    zip = value;
                else
                    errorMessages += "\n ERROR: Not a correct zip, try again.";
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
                if (GeneralTools.NullCheck(value))
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
                if (!GeneralTools.isPastDate(value) && GeneralTools.NullCheck(value))
                    estimatedCompletionDate = value;
                else
                    errorMessages += "\n ERROR: Date cannot be a past date.";
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
                if (GeneralTools.NullCheck(value))
                    completionDate = value;
            }
        }

        public double EstimatedJobCost
        {
            get
            {
                return estimatedJobCost;
            }
            set
            {
                if (GeneralTools.NotEmptyOrNull(value))
                    estimatedJobCost = value;
                else
                    errorMessages += "\n ERROR: Number is not a propr decimal number example: 5.96";
            }
        }

        public double CompletedJobCost
        {
            get
            {
                return completedJobCost;
            }
            set
            {
                if (GeneralTools.NotEmptyOrNull(value))
                    completedJobCost = value;
                else
                    errorMessages += "\n ERROR: Number is not a propr decimal number example: 5.96";
            }
        }

        public string ErrorMessages
        {
            get
            {
                return errorMessages;
            }
        }
    }
}