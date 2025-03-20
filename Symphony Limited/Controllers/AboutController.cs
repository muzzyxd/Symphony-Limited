using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Data;
using Symphony_Limited.Models;

namespace Symphony_Limited.Controllers
{
    public class AboutController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AboutController(ApplicationDbContext context)
        {

            _context = context;

        }

        public async Task<IActionResult> ShowContent()
        {
            var abouts = await _context.Abouts.ToListAsync();
            return View(abouts);
        }

        public IActionResult AddContent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddContent(About about)
        {
            if (ModelState.IsValid)
            {
                await _context.Abouts.AddAsync(about);
                _context.SaveChanges();
                return RedirectToAction("ShowContent");
            }
            return View(about);
        }

        public async Task<IActionResult> EditAbout(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            if (about == null)
            {
                return NotFound();
            }
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> EditAbout(About about)
        {
            if (ModelState.IsValid)
            {
                _context.Abouts.Update(about);
                await _context.SaveChangesAsync();
                return RedirectToAction("ShowContent");
            }
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var about = await _context.Abouts.FindAsync(id);
            if (about != null)
            {
                _context.Abouts.Remove(about);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ShowContent");
        }
    }
}
