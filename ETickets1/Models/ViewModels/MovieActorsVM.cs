namespace ETickets1.Models.ViewModels
{
    public class MovieActorsVM
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
