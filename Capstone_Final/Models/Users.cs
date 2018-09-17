using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Final.Models
{
    public class Users
    {
        private int userID;
        private string firstName;
        private string lastName;
        private string accountName;
        private string email;
        private string password;
        private string salt;
        private int role;
        private DateTime creationDate;
        private bool passwordResetFlag;
        private string errorMessages = string.Empty;


        public int UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
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
                if(GeneralTools.NotEmptyOrNull(value) && GeneralTools.ProfanityChecker(value))
                    firstName = value;
                else
                    errorMessages += "\n ERROR: Name entered is invalid with profanity";
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
                    errorMessages += "\n ERROR: Name entered is invalid with profanity";
            }
        }



        public string AccountName
        {
            get
            {
                return accountName;
            }
            set
            {
                if (GeneralTools.NotEmptyOrNull(value) && GeneralTools.ProfanityChecker(value))
                    accountName = value;
                else
                    errorMessages += "\n ERROR: Name entered is invalid with profanity";
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
                    errorMessages += "\n ERROR: E-mail entered is invalid, try again.";
            }
        }


        public int Role
        {
            get
            {
                return role;
            }
            set
            {
                if(GeneralTools.NotEmptyOrNull(value))
                    role = value;
                else
                    errorMessages += "\n ERROR: Role entered is invalid.";
            }

        }



        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
            set
            {
                if(GeneralTools.NullCheck(value))
                    creationDate = value;
            }
        }



        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                Passwords pass = new Passwords(value);

                if (pass.StrongEnough() && GeneralTools.NotEmptyOrNull(value))
                    password = value;
                else
                    errorMessages += pass.Errors;
            }
        }



        public string Salt
        {
            get
            {
                return salt;
            }
            set
            {
                salt = value;
            }
        }

        public bool PasswordResetFlag
        {
            get
            {
                return passwordResetFlag;
            }
            set
            {
                passwordResetFlag = value;
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