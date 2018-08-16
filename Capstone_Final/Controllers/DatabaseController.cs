using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_Final.Models;

namespace Capstone_Final.Controllers
{
    public class DatabaseController
    {
        public string TryAddUser(Users user)
        {
            if(user.Role == (int)Roles.RoleTypes.Admin)
            {
                string error = string.Empty;
               return Database.AddUser(user, out error);
            }

            return "Cannot do this shit";
            
        }
    }
}