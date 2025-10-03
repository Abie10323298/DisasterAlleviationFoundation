using DisasterAlleviationFoundation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisasterAlleviationFoundation.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult verifyLogin()
        {
            string email;
            string password;

            email = Request.Form["email"].ToString();
            password = Request.Form["password"].ToString();
            Login log = new Login();
            
            bool isValid = log.loginUser(email, password);

            if (isValid)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Login");
            }
        }
    }
}
