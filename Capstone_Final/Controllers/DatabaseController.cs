using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone_Final.Models;
using System.Data;
using System.Data.SqlClient;

namespace Capstone_Final.Controllers
{
    public static class DatabaseController
    {
        /*
        #region User Controls

        public static string TryAddUser(Users currentUser, Users targetUser)
        {
            if (currentUser != null)
            {
                if (currentUser.Role == Roles.Admin)
                {
                    string error = string.Empty;
                    return Database.AddUser(targetUser);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TryUpdateUser(Users currentUser, Users targetUser)
        {
            if (currentUser != null)
            {
                if (currentUser.Role == Roles.Admin)
                {
                    string error = string.Empty;
                    return Database.UpdateUser(targetUser, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }


        public static string TrySearchUser(string accountName, Users user)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin)
                {
                    Users userResult = new Users();
                    string error = string.Empty;
                    return Database.SearchUser(accountName, out userResult);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }


        public static string TrySearchUser(string column, string searchTerm, Users user)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin)
                {
                    Users userResult = new Users();
                    string error = string.Empty;
                    return Database.SearchUser(column, searchTerm, out userResult);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }


        public static string TryChangePassword(Users user, string newPassword)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin)
                {
                    string error = string.Empty;
                    return Database.UpdatePassword(user, newPassword);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TryDeleteUser(Users currentUser, Users targetUser)
        {
            if (currentUser != null)
            {
                if (currentUser.Role == Roles.Admin)
                {
                    string error = string.Empty;
                    return Database.UpdateUser(targetUser, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string PasswordReset(Users currentUser, Users targetUser)
        {
            if (currentUser != null)
            {
                if (currentUser.Role == Roles.Admin)
                {
                    string error = string.Empty;
                    return Database.UpdateUser(targetUser, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string 

        #endregion

        #region Customer Controls
        public static string TryAddCustomer(Users user, Customers customer)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant || user.Role == Roles.Contractor)
                {
                    string error = string.Empty;
                    return Database.AddCustomer(customer);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TryUpdateCustomer(Users user, Customers Customer)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant)
                {
                    string error = string.Empty;
                    return Database.UpdateCustomer(Customer, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TryLocateCustomer(Users user, int customerID, out Customers customer)
        {
            customer = new Customers();
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant)
                {
                    return Database.LocateCustomer(customerID, out customer);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TrySearchCustomers(Users user, string searchTerm, string column, Customers customer)
        {
            customer = new Customers();
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant)
                {
                    string error = string.Empty;
                    return Database.SearchCustomers(searchTerm, column, out customer);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TryDeleteCustomer(Users user, Customers customer)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant || user.Role == Roles.Contractor)
                {
                    string error = string.Empty;
                    return Database.DeleteCustomer(customer, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        #endregion

        #region Job Controls
        public static string TryAddJob(Users user, Jobs job)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant || user.Role == Roles.Contractor)
                {
                    string error = string.Empty;
                    return Database.AddJob(job, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TryUpdateJob(Users user, Jobs job)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant)
                {
                    string error = string.Empty;
                    return Database.UpdateJob(job, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TryLocateJob(Users user, int jobID, out Jobs job)
        {
            job = new Jobs();
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant)
                {
                    return Database.LocateJob(jobID, out job);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TrySearchJobs(Users user, string searchTerm, string column, Jobs job)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant)
                {
                    string error = string.Empty;
                    return Database.SearchJob(searchTerm, column, out job);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TryDeleteJob(Users user, Jobs job)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant || user.Role == Roles.Contractor)
                {
                    string error = string.Empty;
                    return Database.DeleteJob(job, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }
        #endregion

        #region Transaction Controls
        public static string TryAddTransaction(Users user, Transactions transaction)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant)
                {
                    string error = string.Empty;
                    return Database.AddTransaction(transaction, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TryUpdateTransaction(Users user, Transactions transaction)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant)
                {
                    string error = string.Empty;
                    return Database.UpdateTransaction(transaction, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TrySearchTransaction(Users user, string searchTerm, string column, Transactions transaction)
        {
            transaction = new Transactions();
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant)
                {
                    string error = string.Empty;
                    return Database.SearchTransactions(searchTerm, column, out transaction);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        public static string TryDeleteTransaction(Users user, Transactions transaction)
        {
            if (user != null)
            {
                if (user.Role == Roles.Admin || user.Role == Roles.Accountant)
                {
                    string error = string.Empty;
                    return Database.DeleteTransaction(transaction, out error);
                }
                else
                {
                    return "You do not have permission for this action";
                }
            }
            return "Error, user is null";
        }

        #endregion
    }
    
}