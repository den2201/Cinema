using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Windows;
using Cinema.Helpers;
using Cinema.Models;
using Cinema.Models.Domain;
using Cinema.Models.Interfaces;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace Cinema.Services
{
    public class JsonTicketService : ITicketService
    {
        HttpContext Conext { get; set; }
        FileModel fileModel;
       
        private string pathToJson = @"Files\jsonRepository.json";
        
      
        public JsonTicketService()
        {
           CreateTempJson(pathToJson);
        }

        private void CreateTempJson(string jsonPath)
        {

            Film[] movies = new Film[]
        {
                new Film {FilmID = 1, Title = "Terminator", Director = "Moore", PosterUrl = "data:image/jpeg;base64,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", MinAge = 18, Ganres = new Ganre [] {Ganre.Action, Ganre.Fantastic}, ReleaseDate = 2003, Rating = 7.9f },
                new Film {FilmID = 2, Title = "Killer", Director = "Abrams", MinAge = 16, Ganres = new Ganre [] {Ganre.Action, Ganre.Comedy}, ReleaseDate = 2020, Rating = 3.7f }
        };

            Hall [] halls = new Hall[]
            {
                new Hall {HallId = 1, HallName = "GreenHall", Places = 45},
                new Hall { HallId = 2, HallName = "RedHall", Places = 180}

            };
             TimeSlot [] TimeSlots = new TimeSlot[]
            {
                new TimeSlot {Id =1, format = Format.TwoD, Hall = halls[0],
                    Film = movies[1], DateTime = new DateTime(2020, 7, 22, 16,45, 0,0), Cost = 200},
                 new TimeSlot {Id =2, format = Format.Imax, Hall = halls[1],
                    Film = movies[0], DateTime = new DateTime(2020, 8, 15, 7,30, 0,0), Cost = 100},
            };

             fileModel = new FileModel
            {
                Films = movies,
                Halls = halls,
                TimeSlots = TimeSlots
            };
            //try
            //{
            //    File.WriteAllText(jsonPath, JsonConvert.SerializeObject(fileModel));
            //}
            //catch(Exception e)
            //{
            //    MessageBox.Show($"error {e}", e.ToString());
            //    Logger.getInstance().WriteLog(e.ToString());
            //}
        }

        public IEnumerable<Film> GetAllFilms()
        {
             return fileModel.Films;
        }

        public IEnumerable<Hall> GetAllHalls()
        {
            return fileModel.Halls;
        }

        public IEnumerable<TimeSlot> GetAllTimeSlots()
        {
            return fileModel.TimeSlots;

        }

        public Film GetFilmById(int id)
        {
            var film = fileModel.Films.FirstOrDefault(x => x.FilmID == id);
            return film;
            
        }

        public Hall GetHallById(int id)
        {
            throw new System.NotImplementedException();
        }

        public TimeSlot GetTimeSlotById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateFilm(Film film)
        {
            var fullModel = GetDataFromJsonFile();
            var movieToUpdate = 
                fullModel.Films.FirstOrDefault(x => x.FilmID == film.FilmID);

            if (movieToUpdate == null) 
            {
                return false;
            }
            movieToUpdate.MovieUpdate(film);
            SaveDataInFile(fullModel);
            return true;
        }

        private void SaveDataInFile(FileModel info)
        {
            var file = Conext.Server.MapPath(pathToJson);
            var SerializedModel = JsonConvert.SerializeObject(info);
            File.WriteAllText(file, SerializedModel);



        }

        private FileModel GetDataFromJsonFile()
        {
            try
            {
                var file = Conext.Server.MapPath(pathToJson);
                return JsonConvert.DeserializeObject<FileModel>(file);
            }

            catch(FileLoadException e)
            {
                Logger.getInstance().WriteLog(e.ToString());
            }

            catch(FileNotFoundException  e)
            {
                Logger.getInstance().WriteLog(e.ToString());
            }

            catch(JsonException e)
            {
                Logger.getInstance().WriteLog(e.ToString());
            }
            return null;
        }

    }
}
