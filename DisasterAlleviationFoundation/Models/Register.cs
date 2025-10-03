using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace DisasterAlleviationFoundation.Models
{
    public class Register
    {
        SqlConnection conn = new SqlConnection(@"Server=tcp:poeappr.database.windows.net,1433;Initial Catalog=Disaster Alleviation Foundation;Persist Security Info=False;User ID=st10323298;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public string firstName { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string password { get; set; }


        public Register()
        {
            this.firstName = "No name";
            this.surname = "No surname";
            this.email = "No email";
            this.password = "No password";

        }

        public Register(string FirstName, string Surname, string Email, string Password)
        {
            firstName = FirstName;
            surname = Surname;
            email = Email;
            password = Password;
        }

        public void addUser(ref int rowCount, ref string exceptionMsg)
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand($"INSERT INTO users(FirstName,Surname,Email,Password,UserType) VALUES('{firstName}', '{surname}', '{email}', '{password}','{1}' )", conn);

                conn.Open();
                rowCount = insertCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                exceptionMsg = ex.Message;
            }
               
        }
    }
}
