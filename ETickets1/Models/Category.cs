namespace ETickets1.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
