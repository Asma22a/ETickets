namespace ETickets1.Models.ViewModels
{
    public class ActorMovieRelatedVM
    {
        public int Id { get; set; }
        public Actor Actor { get; set; }
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
