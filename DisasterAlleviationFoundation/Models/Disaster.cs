using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace DisasterAlleviationFoundation.Models
{
    public class Disaster
    {
        SqlConnection conn = new SqlConnection(@"Server=tcp:poeappr.database.windows.net,1433;Initial Catalog=Disaster Alleviation Foundation;Persist Security Info=False;User ID=st10323298;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public string disasterType { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string aidType { get; set; }

        public Disaster()
        {
            this.disasterType = "No type";
            this.startDate = "No date";
            this.endDate = "No date";
            this.location = "No location";
            this.description = "No description";
            this.aidType = "No aid type";
        }

        public Disaster(string DisasterType, string StartDate, string EndDate, string Location, string Description, string AidType)
        {
            disasterType = DisasterType;
            startDate = StartDate;
            endDate = EndDate;
            location = Location;
            description = Description;
            aidType = AidType;
        }

        public void addDisaster()
        {
            try
            {
                SqlCommand insertCmd = new SqlCommand($"INSERT INTO DisasterTB(DisasterType,StartDate,EndDate,Location,Description,aidType) VALUES ('{disasterType}','{startDate}','{endDate}','{location}','{description}','{aidType}')", conn);
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
