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
                payment = value;
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
                originalJobCost = value;
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
                newJobCost = value;
            }
        }
    }
}