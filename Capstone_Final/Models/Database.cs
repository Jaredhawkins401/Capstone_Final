using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Helpers;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace Capstone_Final.Models
{
    public static class Database
    {
        private static string ConnString()
        {
            //capstonefinal.database.windows.net
            //jhawkins
            //Serverpass1!
            return "Server=capstonefinal.database.windows.net;Database=CapstoneFinal;User Id=jhawkins;password=Serverpass1!;"; //connection string

        }
        #region User Methods

        public static string AddUser(Users user)
        {
            string attempt = string.Empty;
            string hashedPassword = string.Empty;
            user.Salt = Crypto.GenerateSalt();
            string pass = Crypto.GenerateSalt();


            hashedPassword = Crypto.HashPassword(user.Salt + user.Password);
            int count = hashedPassword.Length;
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConnString();

            string sqlString = "INSERT INTO Users (firstName, lastName, accountName, password, salt, role, creationDate, passwordResetFlag, email) VALUES (@firstName, @lastName, @accountName, @password, @salt, @role, @creationDate, @passwordResetFlag, @email)"; //SQL insert

            SqlCommand comm = new SqlCommand();
            comm.CommandText = sqlString;
            comm.Connection = conn;


            comm.Parameters.AddWithValue("@firstName", user.FirstName);
            comm.Parameters.AddWithValue("@lastName", user.LastName);
            comm.Parameters.AddWithValue("@accountName", user.AccountName);
            comm.Parameters.AddWithValue("@password", hashedPassword);
            comm.Parameters.AddWithValue("@salt", user.Salt);
            comm.Parameters.AddWithValue("@Role", user.Role);
            comm.Parameters.AddWithValue("@CreationDate", DateTime.Now);
            comm.Parameters.AddWithValue("@passwordResetFlag", DBNull.Value);
            comm.Parameters.AddWithValue("@email", user.Email);



            try
            {
                conn.Open();
                int rec = comm.ExecuteNonQuery(); //inserting into table
                attempt += "It worked:" + rec + " records added";
                conn.Close();
            }

            catch (Exception err)
            {
                attempt += "ERROR:" + err.Message;
            }

            finally
            {
            }

            return attempt;
        }

        public static DataSet SearchUser(string searchTerm, string column)
        {
            DataSet userSet = new DataSet();
            Users user = new Users();
            SqlCommand comm = new SqlCommand();

            string SQLquery = "SELECT * FROM Users WHERE 0=0"; //query to grab people who match terms


            if (searchTerm.Length > 0)
            {
                SQLquery += string.Format(" AND {0} = @{1}", column, searchTerm);


                comm.Parameters.AddWithValue(string.Format("@{0}", searchTerm), searchTerm); //adding names to search to narrow down results
            }



            SqlConnection conn = new SqlConnection();
            string conn_string = @ConnString();
            conn.ConnectionString = conn_string;

            comm.Connection = conn;
            comm.CommandText = SQLquery;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            try
            {
                conn.Open();
                adapter.Fill(userSet, "UserTemp"); //fill data set table with info
                conn.Close();

                foreach (DataRow row in userSet.Tables[0].Rows)
                {
                    user.FirstName = row["firstName"].ToString();
                    user.LastName = row["lastName"].ToString();
                    user.AccountName = row["accountName"].ToString();
                    user.Password = row["password"].ToString();
                    user.Salt = row["salt"].ToString();
                    user.Role = (int)row["role"];
                    user.CreationDate = (DateTime)row["creationDate"];
                    user.UserID = (int)row["userID"];
                }
            }
            catch (Exception ex)
            {
            }
            userSet.Tables[0].Columns.Remove("password");
            userSet.Tables[0].Columns.Remove("salt");
            return userSet;
        }
    

        public static string SearchUser(string accountName, out Users user)
        {
            DataSet userSet = new DataSet();
            user = new Users();
            SqlCommand comm = new SqlCommand();

            string SQLquery = "SELECT * FROM Users WHERE 0=0"; //query to grab people who match terms

            if (accountName.Length > 0)
            {
                SQLquery += " AND accountName = @accountName";
                comm.Parameters.AddWithValue("@accountName", accountName); //adding names to search to narrow down results
            }



            SqlConnection conn = new SqlConnection();
            string conn_string = @ConnString();
            conn.ConnectionString = conn_string;

            comm.Connection = conn;
            comm.CommandText = SQLquery;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            try
            {
                conn.Open();
                adapter.Fill(userSet, "UserTemp"); //fill data set table with info
                conn.Close();

                foreach (DataRow row in userSet.Tables[0].Rows)
                {
                    user.FirstName = row["firstName"].ToString();
                    user.LastName = row["lastName"].ToString();
                    user.AccountName = row["accountName"].ToString();
                    user.Password = row["password"].ToString();
                    user.Salt = row["salt"].ToString();
                    user.Role = (int)row["role"];
                    user.CreationDate = (DateTime)row["creationDate"];
                    user.UserID = (int)row["userID"];
                }
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }

            if (user != null)
                return "User was found";
            else
                return "ERROR: User was not found or is empty";
        }

        public static string SearchUser(string searchTerm, string column, out Users user)
        {
            DataSet userSet = new DataSet();
            user = new Users();
            SqlCommand comm = new SqlCommand();

            string SQLquery = "SELECT * FROM Users WHERE 0=0"; //query to grab people who match terms

            if (searchTerm.Length > 0)
            {
                SQLquery = string.Format(" AND {0} = @{1}", column, searchTerm);

                
                comm.Parameters.AddWithValue(string.Format("@{0}", searchTerm), searchTerm); //adding names to search to narrow down results
            }



            SqlConnection conn = new SqlConnection();
            string conn_string = @ConnString();
            conn.ConnectionString = conn_string;

            comm.Connection = conn;
            comm.CommandText = SQLquery;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            try
            {
                conn.Open();
                adapter.Fill(userSet, "UserTemp"); //fill data set table with info
                conn.Close();

                foreach (DataRow row in userSet.Tables[0].Rows)
                {
                    user.FirstName = row["firstName"].ToString();
                    user.LastName = row["lastName"].ToString();
                    user.AccountName = row["accountName"].ToString();
                    user.Password = row["password"].ToString();
                    user.Salt = row["salt"].ToString();
                    user.Role = (int)row["role"];
                    user.CreationDate = (DateTime)row["creationDate"];
                    user.UserID = (int)row["userID"];
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            if (user != null)
                return "User was found";
            else
                return "ERROR: User was not found or is empty";
        }

        public static string SelectPassword(string accountName)
        {

            SqlCommand comm = new SqlCommand();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConnString();
            comm.Connection = conn;

            string sqlQuery = "SELECT password FROM Users WHERE 0=0";
            string pass = string.Empty;

            if (accountName.Length > 0)
            {
                sqlQuery += " AND accountName = @accountName";
                comm.Parameters.AddWithValue("@accountName", accountName);
            }

            comm.CommandText = sqlQuery;

            try
            {
                conn.Open();
                pass = (string)comm.ExecuteScalar();
                conn.Close();
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }

            return pass;
        }

        public static string LocateUser(int userID, out Users user)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            user = new Users();

            string connString = ConnString();

            string sql_query = "SELECT * FROM Users WHERE userID = @userID;"; //query to select 

            conn.ConnectionString = connString;

            comm.Connection = conn;
            comm.CommandText = sql_query;
            comm.Parameters.AddWithValue("@userID", userID); //adds the id you're looking for to query

            try
            {
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    user.FirstName = dr["firstName"].ToString();
                    user.LastName = dr["lastName"].ToString();
                    user.AccountName = dr["accountName"].ToString();
                    user.Password = dr["password"].ToString();
                    user.Salt = dr["salt"].ToString();
                    user.Role = (int)dr["role"];
                    user.CreationDate = (DateTime)dr["creationDate"];
                    user.UserID = (int)dr["userID"];
                    user.PasswordResetFlag = (bool)dr["passwordResetFlag"];
                }

                conn.Close();
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }

            if (user != null)
                return "User was found";
            else
                return "ERROR: User was not found or is empty";
        }

        public static string UpdatePassword(Users user, string newPassword)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            Int32 record = 0;
            string sqlCommand = "UPDATE Users Set password = @password, salt = @salt";
            string result = string.Empty;
            user.Salt = Crypto.GenerateSalt();
            user.Password = Crypto.HashPassword(newPassword + user.Salt);

            conn.ConnectionString = ConnString();
            comm.CommandText = sqlCommand;
            comm.Connection = conn;

            comm.Parameters.AddWithValue("@salt", user.Salt);
            comm.Parameters.AddWithValue("@password", user.Password);

            try
            {
                conn.Open();
                record = comm.ExecuteNonQuery();
                result = record.ToString() + " Records updated";
            }
            catch (Exception err)
            {
                result = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public static string UpdateUser(Users user)
        {
            Int32 record = 0;
            string result = string.Empty;
            string sqlCommand = "UPDATE Users SET firstName = @firstName, lastName = @lastName, role = @role, passwordResetFlag = @passwordResetFlag, email = @email";
 
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConnString();

            SqlCommand comm = new SqlCommand();

            comm.CommandText = sqlCommand;
            comm.Connection = conn;

            comm.Parameters.AddWithValue("@firstName", user.FirstName);
            comm.Parameters.AddWithValue("@lastName", user.LastName);
            comm.Parameters.AddWithValue("@role", user.Role);
            comm.Parameters.AddWithValue("@passwordResetFlag", user.PasswordResetFlag);
            comm.Parameters.AddWithValue("@email", user.Email);

            try
            {
                conn.Open();
                record = comm.ExecuteNonQuery();
                result = record.ToString() + " Records updated";
            }
            catch (Exception err)
            {
                result = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }


        public static string DeleteUser(int userID)
        {
            Int32 record = 0;  //containers to know if deletion occured
            string result = string.Empty;

            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            string conn_string = ConnString();

            string sql_command = "DELETE FROM Users WHERE userID = @userID;"; //statement to delete

            conn.ConnectionString = conn_string;

            comm.Connection = conn;
            comm.CommandText = sql_command;
            comm.Parameters.AddWithValue("@userID", userID);

            try
            {
                conn.Open();

                record = comm.ExecuteNonQuery();
                result = record.ToString() + " Records deleted";
            }
            catch (Exception err)
            {
                result = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();

            }

            return result;
        }

        #endregion

        #region Customer Methods
        public static string AddCustomer(Customers customer)
        {
            string attempt = string.Empty;
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConnString();

            string sqlString = "INSERT INTO Customers (firstName, lastName, street, city, state, zip, email) VALUES (@firstName, @lastName, @street, @city, @state, @zip, @email)"; //SQL insert

            SqlCommand comm = new SqlCommand();
            comm.CommandText = sqlString;
            comm.Connection = conn;


            comm.Parameters.AddWithValue("@firstName", customer.FirstName);
            comm.Parameters.AddWithValue("@lastName", customer.LastName);
            comm.Parameters.AddWithValue("@street", customer.Street);
            comm.Parameters.AddWithValue("@city", customer.City);
            comm.Parameters.AddWithValue("@state", customer.State);
            comm.Parameters.AddWithValue("@zip", customer.Zip);
            comm.Parameters.AddWithValue("@email", customer.Email);




            try
            {
                conn.Open();
                int rec = comm.ExecuteNonQuery(); //inserting into table
                attempt += "It worked:" + rec + " records added";
                conn.Close();
            }

            catch (Exception err)
            {
                attempt += "ERROR:" + err.Message;
            }

            finally
            {
            }

            return attempt;
        }

        public static DataSet SearchCustomers(string searchTerm, string column)
        {

            DataSet customerSet = new DataSet();
            Customers customer = new Customers();
            SqlCommand comm = new SqlCommand();

            string SQLquery = "SELECT * FROM Customers WHERE 0=0"; //query to grab people who match terms

            if (searchTerm.Length > 0)
            {
                SQLquery += " AND @column LIKE @searchTerm";
                comm.Parameters.AddWithValue("@column", column);
                comm.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); //adding names to search to narrow down results
            }


            SqlConnection conn = new SqlConnection();
            string conn_string = @ConnString();
            conn.ConnectionString = conn_string;

            comm.Connection = conn;
            comm.CommandText = SQLquery;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            try
            {
                conn.Open();
                adapter.Fill(customerSet, "customerTemp"); //fill data set table with info
                conn.Close();

                foreach (DataRow row in customerSet.Tables[0].Rows)
                {
                    customer.CustomerID = (int)row["customerID"];
                    customer.FirstName = row["firstName"].ToString();
                    customer.LastName = row["lastName"].ToString();
                    customer.Street = row["street"].ToString();
                    customer.City = row["city"].ToString();
                    customer.State = row["state"].ToString();
                    customer.Zip = row["zip"].ToString();
                    customer.Email = row["email"].ToString();
                }
            }
            catch (Exception ex)
            {
                
            }

            return customerSet;
        }

        public static DataSet SearchCustomersDS(string searchTerm, string column)
        {
            DataSet customerSet = new DataSet();
            Customers customer = new Customers();
            SqlCommand comm = new SqlCommand();

            string SQLquery = "SELECT * FROM Customers WHERE 0=0"; //query to grab people who match terms

            if (searchTerm.Length > 0)
            {
                SQLquery += " AND @column LIKE @searchTerm";
                comm.Parameters.AddWithValue("@column", column);
                comm.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); //adding names to search to narrow down results
            }


            SqlConnection conn = new SqlConnection();
            string conn_string = @ConnString();
            conn.ConnectionString = conn_string;

            comm.Connection = conn;
            comm.CommandText = SQLquery;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            try
            {
                conn.Open();
                adapter.Fill(customerSet, "customerTemp"); //fill data set table with info
                conn.Close();

                foreach (DataRow row in customerSet.Tables[0].Rows)
                {
                    customer.CustomerID = (int)row["customerID"];
                    customer.FirstName = row["firstName"].ToString();
                    customer.LastName = row["lastName"].ToString();
                    customer.Street = row["street"].ToString();
                    customer.City = row["city"].ToString();
                    customer.State = row["state"].ToString();
                    customer.Zip = row["zip"].ToString();
                    customer.Email = row["email"].ToString();
                }
            }
            catch (Exception ex)
            {
            }

            return customerSet;
        }

        public static string SearchCustomers(string searchTerm, string column, out Customers customer)
        {
            DataSet customerSet = new DataSet();
            customer = new Customers();
            SqlCommand comm = new SqlCommand();

            string SQLquery = "SELECT * FROM Customers WHERE 0=0"; //query to grab people who match terms

            if (searchTerm.Length > 0)
            {
                SQLquery += " AND @column LIKE @searchTerm";
                comm.Parameters.AddWithValue("@column", column);
                comm.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); //adding names to search to narrow down results
            }


            SqlConnection conn = new SqlConnection();
            string conn_string = @ConnString();
            conn.ConnectionString = conn_string;

            comm.Connection = conn;
            comm.CommandText = SQLquery;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            try
            {
                conn.Open();
                adapter.Fill(customerSet, "customerTemp"); //fill data set table with info
                conn.Close();

                foreach (DataRow row in customerSet.Tables[0].Rows)
                {
                    customer.CustomerID = (int)row["customerID"];
                    customer.FirstName = row["firstName"].ToString();
                    customer.LastName = row["lastName"].ToString();
                    customer.Street = row["street"].ToString();
                    customer.City = row["city"].ToString();
                    customer.State = row["state"].ToString();
                    customer.Zip = row["zip"].ToString();
                    customer.Email = row["email"].ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            if (customer != null)
                return "Customer was found";
            else
                return "ERROR: Customer was not found or is empty";
        }

 
        public static string LocateCustomer(int customerID, out Customers customer)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            customer = new Customers();

            string connString = ConnString();

            string sql_query = "SELECT * FROM Customers WHERE customerID = @customerID;"; //query to select 

            conn.ConnectionString = connString;

            comm.Connection = conn;
            comm.CommandText = sql_query;
            comm.Parameters.AddWithValue("@customerID", customerID); //adds the id you're looking for to query

            try
            {
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    customer.CustomerID = (int)dr["customerID"];
                    customer.FirstName = dr["firstName"].ToString();
                    customer.LastName = dr["lastName"].ToString();
                    customer.Street = dr["street"].ToString();
                    customer.City = dr["city"].ToString();
                    customer.State = dr["state"].ToString();
                    customer.Zip = dr["zip"].ToString();
                    customer.Email = dr["email"].ToString();

                }

                conn.Close();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            if (customer != null)
                return "Customer was found";
            else
                return "ERROR: Customer was not found or is empty";
        }

        public static string UpdateCustomer(Customers customer)
        {
            Int32 record = 0;
            string result = string.Empty;
            string sqlCommand = "UPDATE Customers SET firstName = @firstName, lastName = @lastName, street = @street, city = @city, state = @state, zip = @zip, email = @email;";

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConnString();

            SqlCommand comm = new SqlCommand();

            comm.CommandText = sqlCommand;
            comm.Connection = conn;

            comm.Parameters.AddWithValue("@firstName", customer.FirstName);
            comm.Parameters.AddWithValue("@lastName", customer.LastName);
            comm.Parameters.AddWithValue("@street", customer.Street);
            comm.Parameters.AddWithValue("@city", customer.City);
            comm.Parameters.AddWithValue("@state", customer.State);
            comm.Parameters.AddWithValue("@zip", customer.Zip);
            comm.Parameters.AddWithValue("@email", customer.Email);

            try
            {
                conn.Open();
                record = comm.ExecuteNonQuery();
                result = record.ToString() + " Records updated";
            }
            catch (Exception err)
            {
                result = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }


        public static string DeleteCustomer(int customerID)
        {
            Int32 record = 0;  //containers to know if deletion occured
            string result = string.Empty;

            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            string conn_string = ConnString();

            string sql_command = "DELETE FROM Customers WHERE customerID = @customerID;"; //statement to delete

            conn.ConnectionString = conn_string;

            comm.Connection = conn;
            comm.CommandText = sql_command;
            comm.Parameters.AddWithValue("@customerID", customerID);

            try
            {
                conn.Open();

                record = comm.ExecuteNonQuery();
                result = record.ToString() + " Records deleted";
            }
            catch (Exception err)
            {
                result = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();

            }

            return result;
        }
        #endregion

        #region Job Methods

        public static string AddJob(Jobs job)
        {
            string attempt = string.Empty;

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConnString();

            string sqlString = "INSERT INTO Jobs (jobID, customerID, street, city, state, zip, startDate, estimatedCompletionDate, completionDate, estimatedJobCost, completedJobCost) VALUES (@jobID, @customerID, @street, @city, @state, @zip, @startDate, @estimatedCompletionDate, @completionDate, @estimatedJobCost, @completedJobCost)"; //SQL insert

            SqlCommand comm = new SqlCommand();
            comm.CommandText = sqlString;
            comm.Connection = conn;


            comm.Parameters.AddWithValue("@jobID", job.JobID);
            comm.Parameters.AddWithValue("@customerID", job.CustomerID);
            comm.Parameters.AddWithValue("@street", job.Street);
            comm.Parameters.AddWithValue("@city", job.City);
            comm.Parameters.AddWithValue("@state", job.State);
            comm.Parameters.AddWithValue("@zip", job.Zip);
            comm.Parameters.AddWithValue("@startDate", job.StartDate);
            comm.Parameters.AddWithValue("@estimatedCompletionDate", job.EstimatedCompletionDate);
            comm.Parameters.AddWithValue("@completionDate", job.CompletionDate);
            comm.Parameters.AddWithValue("@estimatedJobCost", job.EstimatedJobCost);
            comm.Parameters.AddWithValue("@completedJobCost", job.CompletedJobCost);

            try
            {
                conn.Open();
                int rec = comm.ExecuteNonQuery(); //inserting into table
                attempt += "It worked:" + rec + " records added";
                conn.Close();
            }

            catch (Exception err)
            {
                return "ERROR:" + err.Message;
            }

            finally
            {
            }

            return attempt;
        }

        public static DataSet SearchJob(string searchTerm, string column)
        {
            DataSet jobSet = new DataSet();
            Jobs job = new Jobs();
            SqlCommand comm = new SqlCommand();

            string SQLquery = "SELECT * FROM Jobs WHERE 0=0";

            if (searchTerm.Length > 0)
            {
                SQLquery += " AND @column LIKE @searchTerm";
                comm.Parameters.AddWithValue("@column", column);
                comm.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); //adding names to search to narrow down results
            }



            SqlConnection conn = new SqlConnection();

            string conn_string = @ConnString();
            conn.ConnectionString = conn_string;

            comm.Connection = conn;
            comm.CommandText = SQLquery;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            try
            {
                conn.Open();
                adapter.Fill(jobSet, "jobTemp"); //fill data set table with info
                conn.Close();

                foreach (DataRow row in jobSet.Tables[0].Rows)
                {
                    job.JobID = (int)row["jobID"];
                    job.CustomerID = (int)row["customerID"];
                    job.Street = row["street"].ToString();
                    job.City = row["city"].ToString();
                    job.State = row["state"].ToString();
                    job.Zip = row["zip"].ToString();
                    job.StartDate = (DateTime)row["startDate"];
                    job.EstimatedCompletionDate = (DateTime)row["estimatedCompletionDate"];
                    job.EstimatedJobCost = (double)row["estimatedJobCost"];
                    job.CompletedJobCost = (double)row["completedJobCost"];
                }
            }
            catch (Exception ex)
            {

            }

            return jobSet;
        }

        public static string SearchJob(string searchTerm, string column, out Jobs job)
        {
            DataSet jobSet = new DataSet();
            job = new Jobs();
            SqlCommand comm = new SqlCommand();

            string SQLquery = "SELECT * FROM Jobs WHERE 0=0";

            if (searchTerm.Length > 0)
            {
                SQLquery += " AND @column LIKE @searchTerm";
                comm.Parameters.AddWithValue("@column", column);
                comm.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); //adding names to search to narrow down results
            }



            SqlConnection conn = new SqlConnection();

            string conn_string = @ConnString();
            conn.ConnectionString = conn_string;

            comm.Connection = conn;
            comm.CommandText = SQLquery;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            try
            {
                conn.Open();
                adapter.Fill(jobSet, "jobTemp"); //fill data set table with info
                conn.Close();

                foreach (DataRow row in jobSet.Tables[0].Rows)
                {
                    job.JobID = (int)row["jobID"];
                    job.CustomerID = (int)row["customerID"];
                    job.Street = row["street"].ToString();
                    job.City = row["city"].ToString();
                    job.State = row["state"].ToString();
                    job.Zip = row["zip"].ToString();
                    job.StartDate = (DateTime)row["startDate"];
                    job.EstimatedCompletionDate = (DateTime)row["estimatedCompletionDate"];
                    job.EstimatedJobCost = (double)row["estimatedJobCost"];
                    job.CompletedJobCost = (double)row["completedJobCost"];
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            if (job != null)
                return "Job was found";
            else
                return "ERROR: Job was not found or is empty";
        }

        public static string LocateJob(int jobID, out Jobs job)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            job = new Jobs();
            string connStr = ConnString();

            string sqlQuery= "SELECT * FROM Jobs WHERE jobID = @jobID;"; //query to select 

            conn.ConnectionString = connStr;

            comm.Connection = conn;
            comm.CommandText = sqlQuery;
            comm.Parameters.AddWithValue("@jobID", jobID); //adds the id you're looking for to query

            try
            {
                conn.Open();
                SqlDataReader dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    job.JobID = (int)dr["jobID"];
                    job.CustomerID = (int)dr["customerID"];
                    job.Street = dr["street"].ToString();
                    job.City = dr["city"].ToString();
                    job.State = dr["state"].ToString();
                    job.Zip = dr["zip"].ToString();
                    job.StartDate = (DateTime)dr["startDate"];
                    job.EstimatedCompletionDate = (DateTime)dr["estimatedCompletionDate"];
                    job.EstimatedJobCost = (double)dr["estimatedJobCost"];
                    job.CompletedJobCost = (double)dr["completedJobCost"];
                }
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }

            if (job != null)
                return "Job was found";
            else
                return "ERROR: Job was not found or is empty";
        }

        public static string UpdateJob(Jobs job)
        {
            Int32 record = 0;
            string result = "";

            string sql_command = "UPDATE Jobs SET street = @street, city = @city, state = @state, zip = @zip, startDate = @startDate, estimatedCompletionDate = @estimatedCompletionDate, completionDate = @completionDate, estimatedJobCost = @estimatedJobCost, completedJobCost = @completedJobCost WHERE jobID = @jobID";

            SqlConnection conn = new SqlConnection();

            string conn_string = ConnString();
            conn.ConnectionString = conn_string;

            SqlCommand comm = new SqlCommand();

            comm.CommandText = sql_command;
            comm.Connection = conn;


            comm.Parameters.AddWithValue("@street", job.Street);
            comm.Parameters.AddWithValue("@city", job.City);
            comm.Parameters.AddWithValue("@state", job.State);
            comm.Parameters.AddWithValue("@zip", job.Zip);
            comm.Parameters.AddWithValue("@startDate", job.StartDate);
            comm.Parameters.AddWithValue("@estimatedCompletionDate", job.EstimatedCompletionDate);
            comm.Parameters.AddWithValue("@completionDate", job.CompletionDate);
            comm.Parameters.AddWithValue("@estimatedJobCost", job.EstimatedJobCost);
            comm.Parameters.AddWithValue("@completedJobCost", job.CompletedJobCost);


            try
            {
                conn.Open();
                record = comm.ExecuteNonQuery();
                result = record.ToString() + " Records updated";
            }
            catch (Exception err)
            {
                result = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }


        public static string DeleteJob(int jobID)
        {
            Int32 record = 0;  //containers to know if deletion occured
            string result = string.Empty;

            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            string sql_command = "DELETE FROM Jobs WHERE jobID = @jobID;"; //statement to delete

            conn.ConnectionString = ConnString();

            comm.Connection = conn;
            comm.CommandText = sql_command;
            comm.Parameters.AddWithValue("@jobID", jobID);

            try
            {
                conn.Open();

                record = comm.ExecuteNonQuery();
                result = record.ToString() + " Records deleted";
            }
            catch (Exception err)
            {
                result = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();

            }

            return result;
        }
        #endregion

        #region Transaction Methods

        public static string AddTransaction(Transactions transaction)
        {
            string attempt = string.Empty;
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConnString();

            string sql_string = "INSERT INTO Transactions (transactionID, jobID, userID, payment, originalJobCost, newJobCost) VALUES (@transactionID, @jobID, @userID, @payment, @originalJobCost, @newJobCost)"; //SQL insert

            SqlCommand comm = new SqlCommand();
            comm.CommandText = sql_string;
            comm.Connection = conn;


            comm.Parameters.AddWithValue("@transactionID", transaction.TransactionID);
            comm.Parameters.AddWithValue("@jobID", transaction.JobID);
            comm.Parameters.AddWithValue("@userID", transaction.UserID);
            comm.Parameters.AddWithValue("@payment", transaction.Payment);
            comm.Parameters.AddWithValue("@originalJobCost", transaction.OriginalJobCost);
            comm.Parameters.AddWithValue("@newJobCost", transaction.NewJobCost);

            try
            {
                conn.Open();
                int rec = comm.ExecuteNonQuery(); //inserting into table
                attempt += "It worked:" + rec + " records added";
                conn.Close();
            }

            catch (Exception err)
            {
                return "ERROR:" + err.Message;
            }

            finally
            {
            }

            return attempt;
        }

        public static DataSet SearchTransactions(string searchTerm, string column)
        {
            DataSet transactionSet = new DataSet();
            Transactions transaction = new Transactions();
            SqlCommand comm = new SqlCommand();

            string SQLquery = "SELECT * FROM Transactions WHERE 0=0"; //query to grab people who match terms

            if (searchTerm.Length > 0)
            {
                SQLquery += " AND @column LIKE @searchTerm";
                comm.Parameters.AddWithValue("@column", column);
                comm.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); //adding names to search to narrow down results
            }



            SqlConnection conn = new SqlConnection();


            conn.ConnectionString = ConnString();

            comm.Connection = conn;
            comm.CommandText = SQLquery;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            try
            {
                conn.Open();
                adapter.Fill(transactionSet, "transactionTemp"); //fill data set table with info
                conn.Close();

                foreach (DataRow row in transactionSet.Tables[0].Rows)
                {
                    transaction.TransactionID = (int)row["transactionID"];
                    transaction.JobID = (int)row["jobID"];
                    transaction.UserID = (int)row["userID"];
                    transaction.OriginalJobCost = (double)row["originalJobCost"];
                    transaction.NewJobCost = (double)row["newJobCost"];
                }
            }
            catch (Exception ex)
            {
            }

            return transactionSet;
        }

        public static string SearchTransactions(string searchTerm, string column, out Transactions transaction)
        {
            DataSet transactionSet = new DataSet();
            transaction = new Transactions();
            SqlCommand comm = new SqlCommand();

            string SQLquery = "SELECT * FROM Transactions WHERE 0=0"; //query to grab people who match terms

            if (searchTerm.Length > 0)
            {
                SQLquery += " AND @column LIKE @searchTerm";
                comm.Parameters.AddWithValue("@column", column);
                comm.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%"); //adding names to search to narrow down results
            }



            SqlConnection conn = new SqlConnection();


            conn.ConnectionString = ConnString();

            comm.Connection = conn;
            comm.CommandText = SQLquery;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = comm;

            try
            {
                conn.Open();
                adapter.Fill(transactionSet, "transactionTemp"); //fill data set table with info
                conn.Close();

                foreach (DataRow row in transactionSet.Tables[0].Rows)
                {
                    transaction.TransactionID = (int)row["transactionID"];
                    transaction.JobID = (int)row["jobID"];
                    transaction.UserID = (int)row["userID"];
                    transaction.OriginalJobCost = (double)row["originalJobCost"];
                    transaction.NewJobCost = (double)row["newJobCost"];
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            if (transaction != null)
                return "Transaction was found";
            else
                return "ERROR: Transaction was not found or is empty";
        }

        public static string LocateTransaction(int transactionID, out Transactions transaction)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            transaction = new Transactions();
            string connStr = ConnString();

            string sqlQuery = "SELECT * FROM Transactions WHERE transactionID = @transactionID;"; //query to select 

            conn.ConnectionString = connStr;

            comm.Connection = conn;
            comm.CommandText = sqlQuery;
            comm.Parameters.AddWithValue("@transactionID", transactionID); //adds the id you're looking for to query

            conn.Open();
            SqlDataReader dr = comm.ExecuteReader();

            while(dr.Read())      
            {
                transaction.TransactionID = (int)dr["transactionID"];
                transaction.JobID = (int)dr["jobID"];
                transaction.UserID = (int)dr["userID"];
                transaction.Payment = (double)dr["payment"];
                transaction.OriginalJobCost = (double)dr["originalJobCost"];
                transaction.NewJobCost = (double)dr["newJobCost"];
            }

            if (transaction != null)
                return "Transaction was found";
            else
                return "ERROR: Transaction was not found or is empty";
        }

        public static string UpdateTransaction(Transactions transaction)
        {
            Int32 record = 0;
            string result = "";

            string sql_command = "UPDATE Transactions SET payment = @payment, originalJobCost = @originalJobCost, newJobCost = @newJobCost";
            SqlConnection conn = new SqlConnection();

            string conn_string = ConnString();
            conn.ConnectionString = conn_string;

            SqlCommand comm = new SqlCommand();

            comm.CommandText = sql_command;
            comm.Connection = conn;


            comm.Parameters.AddWithValue("@payment", transaction.Payment);
            comm.Parameters.AddWithValue("@originalJobCost", transaction.OriginalJobCost);
            comm.Parameters.AddWithValue("@newJobCost", transaction.NewJobCost);




            try
            {
                conn.Open();
                record = comm.ExecuteNonQuery();
                result = record.ToString() + " Records updated";
            }
            catch (Exception err)
            {
                result = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }


        public static string DeleteTransaction(int transactionID)
        {
            Int32 record = 0;  //containers to know if deletion occured
            string result = string.Empty;


            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();

            string sql_command = "DELETE FROM Transactions WHERE transactionID = @transactionID;"; //statement to delete

            conn.ConnectionString = ConnString();

            comm.Connection = conn;
            comm.CommandText = sql_command;
            comm.Parameters.AddWithValue("@transactionID", transactionID);

            try
            {
                conn.Open();

                record = comm.ExecuteNonQuery();
                result = record.ToString() + " Records deleted";
            }
            catch (Exception err)
            {
                result = "ERROR: " + err.Message;
            }
            finally
            {
                conn.Close();

            }

            return result;
        }
        #endregion

    }
}