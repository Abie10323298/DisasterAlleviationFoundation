using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAlleviationFoundation.Models
{
    public class AllocateDonation
    {
        SqlConnection conn = new SqlConnection(@"Server=tcp:poeappr.database.windows.net,1433;Initial Catalog=Disaster Alleviation Foundation;Persist Security Info=False;User ID=st10323298;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public double amount { get; set; }
        public string disaster { get; set; }

        public AllocateDonation()
        {
            this.amount = 0;
            this.disaster = "No name";
        }

        public AllocateDonation(double Amount, string Disaster)
        {
            amount = Amount;
            disaster = Disaster;
        }

        public void donationAllocation()
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand($"INSERT INTO allocatedMoneyTB(DisasterType,Amount) VALUES('{disaster}','{amount}')", conn);
                conn.Open();
                insertCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void donationGoodsAllocation(string disaster, string donation)
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand($"INSERT INTO allocatedGoodsTB(DisasterType,Donation) VALUES('{disaster}','{donation}')", conn);
                conn.Open();
                insertCmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
