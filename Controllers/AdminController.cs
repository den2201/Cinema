using Cinema.Models;
using Cinema.Models.Domain;
using System;
using Newtonsoft.Json;
using System.Web.Mvc;
using Cinema.Services;
using Cinema.Models.Interfaces;
using System.Collections.Generic;

namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
        ITicketService service = new JsonTicketService();
        // GET: Admin
        public ActionResult Index()
        {
            

            IEnumerable<Film> films = service.GetAllFilms();

            return View("MovieList",films);
        }

        public ActionResult EditMovie(int movieIDd)
        {
            var film = service.GetFilmById();
            return View();
        }
    }
}