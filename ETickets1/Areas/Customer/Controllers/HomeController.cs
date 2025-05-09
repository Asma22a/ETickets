using System.Diagnostics;
using ETickets1.Data;
using ETickets1.Models;
using ETickets1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ETickets1.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string? SearchMovie)
        {
            IQueryable<Movie> movie = _context.Movies.Include(e => e.Cinema).Include(e => e.Category);
            if (SearchMovie is not null)
            {
                movie = movie.Where(e => e.Name.Contains(SearchMovie));
            }
            return View(movie.ToList());
        }
        public IActionResult Details(int id)
        {
            var Movie = _context.Movies.Include(e => e.Cinema).Include(e => e.Category).Where(e => e.Id == id).FirstOrDefault();
            var actorMovie = _context.ActorMovies.Include(e => e.Actor).Where(e => e.MovieId == id);
            MovieActorsVM movieActorsVM = new()
            {
                ActorMovies = actorMovie.ToList(),
                Movie = Movie
            };
            return View(movieActorsVM);
        }
        public IActionResult ActorDetails(int id)
        {
            var Actor = _context.Actors.Find(id);
            var relatedMovie = _context.ActorMovies.Include(e => e.Movie).Where(e => e.ActorId == id);
            ActorMovieRelatedVM actorMovieRelatedVM = new()
            {
                ActorMovies = relatedMovie.ToList(),
                Actor = Actor
            };
            return View(actorMovieRelatedVM);
        }
        public IActionResult Cinema()
        {
            var cinema = _context.Cinemas;
            return View(cinema.ToList());
        }
        public IActionResult AllCinemaMovie(int id)
        {
            var cinema = _context.Cinemas.Include(e => e.Movies).ThenInclude(e => e.Category).Where(e => e.Id == id).FirstOrDefault();
            return View(cinema);
        }
        public IActionResult Category()
        {
            var category = _context.Categories;
            return View(category.ToList());
        }
        public IActionResult AllCategoryMovie(int id)
        {
            var category = _context.Categories.Include(e => e.Movies).ThenInclude(e => e.Cinema).Where(e => e.Id == id).FirstOrDefault();
            return View(category);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
