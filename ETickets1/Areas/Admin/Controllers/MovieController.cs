using ETickets1.Data;
using ETickets1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        public IActionResult AllMovie()
        {
            var movie = _context.Movies.Include(e => e.Category).Include(e => e.Cinema);

            return View(movie.ToList());
        }
        public IActionResult Creat()
        {
            var category = _context.Categories;
            var cinema = _context.Cinemas;
            ViewBag.Category = category.ToList();
            ViewBag.Cinema = cinema.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Creat(Movie movie, IFormFile? ImgUrl)
        {
            if (ImgUrl is not null && ImgUrl.Length > 0)
            {
                var ImgName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\movies", ImgName);
                using (var stream = System.IO.File.Create(path))
                {
                    ImgUrl.CopyTo(stream);
                }
                movie.ImgUrl = ImgName;
            }
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("AllMovie");
        }
        public IActionResult Edit(int id)
        {
            var findMovie = _context.Movies.Find(id);
            var category = _context.Categories;
            var cinema = _context.Cinemas;
            ViewBag.Category = category.ToList();
            ViewBag.Cinema = cinema.ToList();

            return View(findMovie);
        }
        [HttpPost]
        public IActionResult Edit(Movie movie, IFormFile? ImgUrl)
        {
            var MovieInDb = _context.Movies.AsNoTracking().FirstOrDefault(e => e.Id == movie.Id);
            if (MovieInDb == null)
            {
                if (ImgUrl is not null && ImgUrl.Length > 0)
                {
                    var ImgName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\movies", ImgName);
                    using (var stream = System.IO.File.Create(path))
                    {
                        ImgUrl.CopyTo(stream);
                    }
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\movies", MovieInDb.ImgUrl);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                    movie.ImgUrl = ImgName;
                }
            }
            else
            {
                movie.ImgUrl = MovieInDb.ImgUrl;
            }
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("AllMovie");
        }
        public IActionResult Delete(int id)
        {
            var findMovie = _context.Movies.Find(id);
            var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\movies", findMovie.ImgUrl);
            if (System.IO.File.Exists(oldPath))
            {
                System.IO.File.Delete(oldPath);
            }
            _context.Movies.Remove(findMovie);
            _context.SaveChanges();
            return RedirectToAction("AllMovie");
        }
    }
}
