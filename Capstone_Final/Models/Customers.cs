using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Final.Models
{
    public class Customers
    {
        private int customerID;
        private string firstName;
        private string lastName;
        private string street;
        private string city;
        private string state;
        private string zip;
        private string email;
        private string errorMessages;

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

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (GeneralTools.NotEmptyOrNull(value) && GeneralTools.ProfanityChecker(value))
                    firstName = value;
                else
                    errorMessages += "\n ERROR: Name cannot contain profanities.";


            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (GeneralTools.NotEmptyOrNull(value) && GeneralTools.ProfanityChecker(value))
                    lastName = value;
                else
                    errorMessages += "\n ERROR: Name cannot contain profanities.";
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
                    errorMessages += "\n ERROR: Zipcode is incorrect, try again";
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (GeneralTools.EmailValidity(value) && GeneralTools.NotEmptyOrNull(value))
                    email = value;
                else
                    errorMessages += "\n ERROR: Email is incorrect, try again";
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
