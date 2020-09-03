using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Helpers
{
    public static class FilmUpdaterInfo
    {
        public static void MovieUpdate(this Film film,Film cinema )
        {
            film.Title = cinema.Title;
            film.Description = cinema.Description;
            film.Director = cinema.Director;
            film.Duration = cinema.Duration;
            if(cinema.Ganres!=null)
                film.Ganres = cinema.Ganres;
            film.MinAge = cinema.MinAge;
            film.PosterUrl = cinema.PosterUrl;
            film.Rating = cinema.Rating;
            film.ReleaseDate = cinema.ReleaseDate;
        }
    }
}