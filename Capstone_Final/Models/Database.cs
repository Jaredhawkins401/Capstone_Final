using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Capstone_Final.Models
{
    public class Database
    {
        private static string ConnString()
        {
            return "Server=sql.neit.edu,4500;Database=se245_jhawkins;User Id=se245_jhawkins;password=000920011;"; //connection string

        }

        public static string AddUser(Users user, out string errormessages)
        {
            string attempt = string.Empty;
            errormessages = string.Empty;
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = ConnString();

            string sql_string = "INSERT INTO Users (name, role, creationDate) VALUES (@Name, @Role, @CreationDate)"; //SQL insert

            SqlCommand comm = new SqlCommand();
            comm.CommandText = sql_string;
            comm.Connection = conn;


            comm.Parameters.AddWithValue("@Name", user.Name);
            comm.Parameters.AddWithValue("@Lives", user.Role);
            comm.Parameters.AddWithValue("@HoursPlayed", user.CreationDate);



            try
            {
                conn.Open();
                int rec = comm.ExecuteNonQuery(); //inserting into table
                attempt += "It worked:" + rec + " records added";
                conn.Close();
            }

            catch (Exception err)
            {
                errormessages += "ERROR:" + err.Message;
            }

            finally
            {

            }

            return attempt;
        }
    }
}