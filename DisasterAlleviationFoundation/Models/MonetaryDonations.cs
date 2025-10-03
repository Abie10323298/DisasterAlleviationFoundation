using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace DisasterAlleviationFoundation.Models
{
    public class MonetaryDonations
    {
        SqlConnection conn = new SqlConnection(@"Server=tcp:poeappr.database.windows.net,1433;Initial Catalog=Disaster Alleviation Foundation;Persist Security Info=False;User ID=st10323298;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public string firstName { get; set; }
        public string surname { get; set; }
        public double amount { get; set; }
        public string date { get; set; }
        public string email { get; set; }

        public MonetaryDonations()
        {
            this.firstName = "No name";
            this.surname = "No surname";
            this.amount = 0;
            this.date = "No Date";
            this.email = "No email";
        }

        public MonetaryDonations(string FirstName, string Surname, double Amount, string Date, string Email)
        {
            firstName = FirstName;
            surname = Surname;
            amount = Amount;
            date = Date;
            email = Email;
        }

        public void addDonation()
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand($"INSERT INTO monetaryDonationsTB(FirstName,Surname,Amount,Date,Email) VALUES ('{firstName}','{surname}','{amount}','{date}','{email}')", conn);
                conn.Open();
                insertCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {

               throw ex;
            }
        }

        //Adds all amounts together to get total amount donated
        public double totalDonationsAmount()
        {

            double amountTotal = 0;
            try
            {
                
                SqlCommand selectCmd = new SqlCommand($"SELECT SUM(Amount) FROM monetaryDonationsTB", conn);
                conn.Open();
                amountTotal = selectCmd.ExecuteNonQuery();
                conn.Close();
   
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return amountTotal;
        }

        //Adds the updated total value to the database.
        public void addTotal()
        {
            try
            {
                SqlCommand updateCmd = new SqlCommand($"UPDATE totalAmountTB SET Amount = '{totalDonationsAmount()}' WHERE AmountID = '{1}'", conn);
                conn.Open();
                updateCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
