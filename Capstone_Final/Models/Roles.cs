using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone_Final.Models
{
    public class Roles
    {
        public enum RoleTypes
        {
            Admin = 1,
            Accountant = 2,
            General = 3,
            Guest = 4

        }


        private int Admin()
        {
            return (int)RoleTypes.Admin;
        }
    }
}