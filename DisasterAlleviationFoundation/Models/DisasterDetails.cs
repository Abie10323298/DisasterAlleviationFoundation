using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAlleviationFoundation.Models
{
    public class DisasterDetails 
    {
        public SelectList Disasters { get; set; }

        public void onGet()
        {
           // this.Disasters = new SelectList(populateDisaster(), "disasterName", "location", "aidType");
        }

        public void OnPostSubmit(GetDisasterDetail disaster)
        {
            string message = "Disaster Name: " + disaster.disasterName;
            message += "\\Location: " + disaster.location;
            message += "\\aid Type: " + disaster.aidType;
            //ViewData["Messagae"] = message;
        }
        
        /**
        private static List<GetDisasterDetail> populateDisaster()
        {
            string connect = @"Server=tcp:st10131148.database.windows.net,1433;Initial Catalog=disasterAlleviationDB;Persist Security Info=False;User ID=st10131148;Password=Somevice62;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

            List<GetDisasterDetail> disaster = new List<GetDisasterDetail>();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "SELECT DisasterType, Location, aidType FROM DisasterTB";
                using (SqlCommand selectCmd = new SqlCommand(query))
                {
                    selectCmd.Connection = conn;
                    conn.Open();
                    using (SqlDataAdapter sdr = selectCmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            disaster.Add(new GetDisasterDetail
                            {
                                disasterName = sdr.["DisasterType"].ToString(),
                                location = sdr.["Location"].ToString(),
                                aidType = sdr.["aidType"].ToSring(),
                            });
                        }
                    }
                    conn.Close();
                }
            }
            return disaster;
        } **/
    }
}
