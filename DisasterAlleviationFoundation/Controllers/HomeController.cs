using DisasterAlleviationFoundation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DisasterAlleviationFoundation.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        SqlConnection conn = new SqlConnection();
        List<DisplayDonations> donations = new List<DisplayDonations>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            conn.ConnectionString = @"Server=tcp:poeappr.database.windows.net,1433;Initial Catalog=Disaster Alleviation Foundation;Persist Security Info=False;User ID=st10323298;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public IActionResult Index()
        {
            MonetaryDonations monDon = new MonetaryDonations();
            monDon.addTotal();
            return View();
        }
        [HttpPost]
        //For Monetary Donationa page
        public IActionResult captureDonation()
        {

            string firstName, surname, email;
            double amount;
            string date;

            firstName = Request.Form["donorName"].ToString();
            surname = Request.Form["donorSurname"].ToString();
            email = Request.Form["email"].ToString();
            amount =  Convert.ToDouble(Request.Form["amount"]);
            date = Request.Form["date"].ToString();
            MonetaryDonations moDon = new MonetaryDonations(firstName, surname, amount, date, email);
            moDon.addDonation();


            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult captureGoodsDonations()
        {

            string firstName, surname, email;
            int itemsNum;
            string category, description;
            string date;

            firstName = Request.Form["donorName"].ToString();
            surname = Request.Form["donorSurname"].ToString();
            email = Request.Form["email"].ToString();
            itemsNum = Convert.ToInt32(Request.Form["noOfItems"]);
            date = Request.Form["date"].ToString();
            category = Request.Form["category"].ToString();
            description = Request.Form["description"].ToString();
            GoodDonations goDon = new GoodDonations(firstName, surname, date, itemsNum, category, description, email);
            goDon.addDonation();

            return RedirectToAction("Privacy", "Home");
        }

        public IActionResult Disaster()
        {
            return View();
        }

        public IActionResult captureDisaster()
        {
            string startDate, endDate;
            string location, desciption;
            string aidType, disasterType;

            disasterType = Request.Form["disasterName"].ToString();
            startDate = Request.Form["startDate"].ToString();
            endDate = Request.Form["endDate"].ToString();
            location = Request.Form["location"].ToString();
            desciption = Request.Form["description"].ToString();
            aidType = Request.Form["aidType"].ToString();

            Disaster dis = new Disaster(disasterType,startDate,endDate,location,desciption,aidType);
            dis.addDisaster();

            return RedirectToAction("Disaster", "Home");
        }

        public IActionResult DisplayDonations()
        {
            fetchData();
            return View();
        }

        public IActionResult AllocateDonations()
        {
            return View();
        }

        public IActionResult getMoneyAllocation()
        {
            double amount;
            string disaster;

            amount = Convert.ToDouble(Request.Form["allocatedAmount"]);
            disaster = Request.Form["disaster"].ToString();

            AllocateDonation allDon = new AllocateDonation(amount, disaster);
            allDon.donationAllocation();


            return RedirectToAction("AllocateDonations", "Home");
        }

        public double getTotal()
        {
            double total;
            MonetaryDonations moDon = new MonetaryDonations();
            total = moDon.totalDonationsAmount();

            return total;
             
        }

        public IActionResult getGoodsAllocation()
        {
            string donation, disaster;

            donation = Request.Form["donation"].ToString();
            disaster = Request.Form["disaster"].ToString();

            AllocateDonation allDon = new AllocateDonation();
            allDon.donationGoodsAllocation(disaster, donation);

            return RedirectToAction("AllocateDonations", "Home");
        }
        /**
        public ActionResult getAmount()
        {
            double total;
            MonetaryDonations moDon = new MonetaryDonations();
            total = moDon.totalDonationsAmount();

            List<double> amount = new List<double>();
            amount.Add(total);

            this.ViewData["amount"] = amount;
            this.ViewBag.amount = amount;
            this.TempData["amount"] = amount;
           // this.HttpContext.Session["amount"] = amount;

            return View();

        }**/

        private void fetchData()
        {
            if(donations.Count > 0)
            {
                donations.Clear();
            }
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT FirstName,Surname,Amount,Date FROM [monetaryDonationsTB]";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    donations.Add(new DisplayDonations() { firstName = dr["FirstName"].ToString() 
                    ,surname = dr["Surname"].ToString()
                    ,amount = Convert.ToDouble(dr["Amount"])
                    ,date = dr["Date"].ToString()
                    });
                }
                conn.Close(); ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
