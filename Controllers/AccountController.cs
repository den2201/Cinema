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
        public ActionResult Login()
        {
            var loginModel = new LoginModel();
            return View(loginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            return View("AccountAccepted",model);
        }
    }
}