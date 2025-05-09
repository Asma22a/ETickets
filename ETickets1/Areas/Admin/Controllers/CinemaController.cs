using ETickets1.Data;
using ETickets1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETickets1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CinemaController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        public IActionResult AllCinema()
        {
            var cinema = _context.Cinemas;
            return View(cinema.ToList());
        }
        public IActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Creat(Cinema cinema)
        {

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return RedirectToAction("AllCinema");
        }
        public IActionResult Edit(int id)
        {
            var findCinema = _context.Cinemas.Find(id);

            return View(findCinema);
        }
        [HttpPost]
        public IActionResult Edit(Cinema cinema)
        {
            _context.Cinemas.Update(cinema);
            _context.SaveChanges();
            return RedirectToAction("AllCinema");
        }

        public IActionResult Delete(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return RedirectToAction("AllCinema");
        }
    }
}
