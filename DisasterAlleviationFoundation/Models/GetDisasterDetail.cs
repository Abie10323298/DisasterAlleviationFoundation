using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAlleviationFoundation.Models
{
    public class GetDisasterDetail
    {
        //SqlConnection conn = new SqlConnection(@"Server=tcp:st10131148.database.windows.net,1433;Initial Catalog=disasterAlleviationDB;Persist Security Info=False;User ID=st10131148;Password=Somevice62;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public string disasterName { get; set; }
        public string location { get; set; }
        public string aidType { get; set; }
        
        /**
        public void getData()
        {
            GetDonationDetail[] allRecords = null;
            string sql = @"SELECT DisasterType, Location, aidType FROM DisasterTB";
            using (var command = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = command.ExecuteReader())
                {
                    var list = new List<GetDonationDetail>();
                    while (reader.Read())
                        list.Add(new GetDonationDetail { disasterName = reader.GetString(0), location = reader.GetString(0), aidType = reader.GetString(0) });
                    allRecords = list.ToArray();
                }
            }
        } **/
    } 
}
