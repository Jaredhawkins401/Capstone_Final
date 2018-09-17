using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Final.Models
{
    public class Roles
    {
        public enum RoleTypes : int
        {
            Admin = 1,
            Accountant = 2,
            Contractor = 3,
            General = 4

        }


        public static int Admin
        {
            get
            {
                return (int)RoleTypes.Admin;
            }
        }

        public static int Accountant
        {
            get
            {
                return (int)RoleTypes.Accountant;
            }
        }

        public static int Contractor
        {
            get
            {
                return (int)RoleTypes.Contractor;
            }
        }

        public static int General
        {
            get
            {
                return (int)RoleTypes.General;
            }
        }
    }
}