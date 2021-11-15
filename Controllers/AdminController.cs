using Cinema.Models;
using Cinema.Models.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _host;
        const string path =  "/Files/data.json";
        public AdminController(IWebHostEnvironment env)
        {
            _host = env;
        }
        public IActionResult Index()
        {
            var movies = new Movie []
            {
                new Movie { 
                    Id = 1,
                    Title = "Once in HollyWood",
                    Description = "hdfgdjfgdsfg", 
                    Director ="Tarantino",
                    Duration = 161,
                    Genres=new Genre []{  Genre.Comedy, Genre.Drama }, 
                    ImageUrl = "dfsdfsdf", 
                    MinAge = 18, 
                    Rateing = 7.6f, 
                    ReleaseDate = 2019
                }
            };

            var halls = new Hall[] { 
                new Hall {
                    Id = 1,
                    Name = "Hall 1",
                    Places = 60
                },
                 new Hall {
                    Id = 2,
                    Name = "Hall 2",
                    Places = 35
                }
            };

            var timeSlots = new TimeSlot[] {
                new TimeSlot {
                    Id = 1,
                    Hall = halls[0],
                    Movie = movies[0],
                    Cost = 170,
                    Format = Format.TwoD,
                    StartTime = new DateTime(2019, 01, 22, 21, 10, 00)
                },
                  new TimeSlot {
                    Id = 2,
                    Hall = halls[1],
                    Movie = movies[0],
                    Cost = 350,
                    Format = Format.Imax,
                    StartTime = new DateTime(2019, 01, 22, 21, 10, 00)
                }
            };

            var fileModel = new FileModel
            {
                Movies = movies,
                Halls = halls,
                TimeSlots = timeSlots
            };
         
            System.IO.File.WriteAllText(_host.ContentRootPath + path, JsonConvert.SerializeObject(fileModel), System.Text.Encoding.UTF8);
            return View();
        }

        public IActionResult GetTicket ()
        {
            var data = System.IO.File.ReadAllText(_host.ContentRootPath + "\\Files\\data.json");
            
            var model = JsonConvert.DeserializeObject<FileModel>(data);
            return View();
        }
    }
}
