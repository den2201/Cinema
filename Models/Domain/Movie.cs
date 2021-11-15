namespace Cinema.Models.Domain
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public Genre[] Genres { get; set; }

        public int MinAge { get; set; }
        public string Director { get; set; }

        public string ImageUrl { get; set; }
       
        public float Rateing { get; set; }

        public int? ReleaseDate { get; set; }

    }
}
