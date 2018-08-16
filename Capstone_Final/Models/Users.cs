using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Final.Models
{
    public class Users
    {
        private int id;
        private string name;
        private int role;
        private DateTime creationDate;
        private string errorMessages;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
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
                role = value;
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
                creationDate = value;
            }
        }

        public string ErorMessages
        {
            get
            {
                return ErorMessages;
            }
        }

        public Users()
        {
            id = 0;
            name = "New Employee";
            role = 1;
            creationDate = DateTime.Today;
            errorMessages = string.Empty;
        }

    }
}