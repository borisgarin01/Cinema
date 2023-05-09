using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult LogIn()
        {
            LogIn myLogin = new Models.LogIn();
            return View("~/Views/LogIn.cshtml");
        }

        [HttpPost]
        public ActionResult LogOut(LogIn loginResult) 
        {
            if(ModelState.IsValid)
            {
                return View("~/Views/LogInResult.cshtml", loginResult);
            }
            return View("~/Views/LogIn.cshtml", loginResult);
        }
    }
}