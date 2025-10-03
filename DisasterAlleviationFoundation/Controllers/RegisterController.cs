using DisasterAlleviationFoundation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAlleviationFoundation.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult verifyRegister()
        {

                string firstName, surname;
                string email;
                string password;
                string cpassword;
                int rowCount = 0;
                string errorMsg = string.Empty;

                firstName = Request.Form["firstName"].ToString();
                surname = Request.Form["surname"].ToString();
                email = Request.Form["email"].ToString();
                password = Request.Form["password"].ToString();
                cpassword = Request.Form["cpassword"].ToString();

                Register reg = new Register(firstName, surname, email, password);

                reg.addUser(ref rowCount, ref errorMsg);

                return RedirectToAction("Login", "Login");

    
        }
    }
}
