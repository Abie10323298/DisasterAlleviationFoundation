using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace DisasterAlleviationFoundation.Models
{
    public class GoodDonations
    {
        SqlConnection conn = new SqlConnection(@"Server=tcp:poeappr.database.windows.net,1433;Initial Catalog=Disaster Alleviation Foundation;Persist Security Info=False;User ID=st10323298;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public string firstName { get; set; }
        public string surname { get; set; }
        public string date { get; set; }
        public int itemsNum { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string email { get; set; }

        public GoodDonations()
        {
            this.firstName = "No name";
            this.surname = "No surname";
            this.date = "No date";
            this.itemsNum = 0;
            this.category = "No category";
            this.description = "No description";
            this.email = "No email";
        }

        public GoodDonations(string FirstName, string Surname, string Date, int ItemsNum, string Category, string Description, string Email)
        {
            firstName = FirstName;
            surname = Surname;
            date = Date;
            itemsNum = ItemsNum;
            category = Category;
            description = Description;
            email = Email;
        }

        public void addDonation()
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand($"INSERT INTO goodsDonationsTB(FirstName,Surname,Date,NumberOfItems,Category,Description,Email) VALUES ('{firstName}','{surname}','{date}','{itemsNum}','{category}','{description}','{email}')", conn);
                conn.Open();
                insertCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
