using ETickets1.Data;
using ETickets1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETickets1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        public IActionResult AllCategory()
        {
            var category = _context.Categories;
            return View(category.ToList());
        }
        public IActionResult Creat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Creat(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("AllCategory");
        }

        public IActionResult Edit(int id)
        {
            var FindCategory = _context.Categories.Find(id);

            return View(FindCategory);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("AllCategory");
        }
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("AllCategory");

        }
    }
}
