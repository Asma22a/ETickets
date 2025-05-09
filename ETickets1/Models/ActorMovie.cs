using System.ComponentModel.DataAnnotations;

namespace ETickets1.Models
{
    public class ActorMovie
    {
        public int Id { get; set; }
        public int ActorsId { get; set; }
        public int MoviesId { get; set; }

        public Actor? Actor { get; set; } 

        public Movie? Movie { get; set; }
       
    }
}
