using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DisasterAlleviationFoundation.Models
{
    public class Login
    {
        SqlConnection conn = new SqlConnection(@"Server=tcp:poeappr.database.windows.net,1433;Initial Catalog=Disaster Alleviation Foundation;Persist Security Info=False;User ID=st10323298;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public int userID { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public Login()
        {
            this.userID = 0;
            this.email = "No email";
            this.password = "No password";
        }

        public Login(int UserID, string Email, string Password)
        {
            userID = UserID;
            email = Email;
            password = Password;
        }

        public string getEmail(string email)
        {
            string Email = email;
            return Email;
        }

        public bool loginUser(string email, string password)
        {
            SqlDataAdapter select = new SqlDataAdapter($"SELECT * FROM USERS WHERE Email = '{email}' AND Password = '{password}'", conn);
            DataTable dt = new DataTable();

            conn.Open();
            select.Fill(dt);
            conn.Close();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
