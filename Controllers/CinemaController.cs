using Microsoft.AspNetCore.Mvc;
using System;

namespace Cinema.Controllers
{
    public class CinemaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(int? x)
        {
            return View(x);
        }
    }
}
