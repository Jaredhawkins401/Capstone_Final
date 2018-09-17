using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Final.Models
{
    public class Transactions
    {
        private int transactionID;
        private int jobID;
        private int userID;
        private double payment;
        private double originalJobCost;
        private double newJobCost;
        private string errorMessages;

        public int TransactionID
        {
            get
            {
                return transactionID;
            }
            set
            {
                transactionID = value;
            }
        }

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

        public int UserID
        {
            get
            {
                return UserID;
            }
            set
            {
                userID = value;
            }
        }

        public double Payment
        {
            get
            {
                return payment;
            }
            set
            {
                if(GeneralTools.NotEmptyOrNull(value) && GeneralTools.DoubleCheck(value.ToString()))
                    payment = value;
                else
                    errorMessages += "\n ERROR: Number is not a propr decimal number example: 5.96";
            }
        }

        public double OriginalJobCost
        {
            get
            {
                return originalJobCost;
            }
            set
            {
                if(GeneralTools.NotEmptyOrNull(value) && GeneralTools.DoubleCheck(value.ToString()))
                    originalJobCost = value;
                else
                    errorMessages += "\n ERROR: Number is not a propr decimal number example: 5.96";
            }
        }

        public double NewJobCost
        {
            get
            {
                return newJobCost;
            }
            set
            {
                if(GeneralTools.NotEmptyOrNull(value))
                    newJobCost = value;
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