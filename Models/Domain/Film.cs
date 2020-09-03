using Cinema.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models
{
    public class Film
    {
        public int FilmID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public Ganre[] Ganres { get; set; }

        public int MinAge { get; set; }

        public string  Director { get; set; }

        public string PosterUrl { get; set; }

        public float Rating { get; set; }

        public int? ReleaseDate { get; set; }
    }

     
}