namespace ETickets1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public string TrailerUrl { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public MovieStatus MovieStatus { get; set; } = 0;
        public int CinemaId { get; set; }
        public int CategoryId { get; set; }
        public Cinema Cinema { get; set; }
        public Category Category { get; set; }
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public List<ActorMovie> actorMovies { get; set; } = new List<ActorMovie>();

    }
}
