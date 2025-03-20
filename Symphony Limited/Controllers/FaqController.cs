using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Data;
using Symphony_Limited.Models;

namespace Symphony_Limited.Controllers
{
    public class FaqController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FaqController(ApplicationDbContext context)
        {

            _context = context;

        }
        public async Task<IActionResult> AllFaqs()
        {
            var faqs = await _context.Faqs.ToListAsync();
            return View(faqs);
        }

        public IActionResult AddFaq()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFaq(Faq faq)
        {
            if (ModelState.IsValid)
            {
                await _context.Faqs.AddAsync(faq);
                _context.SaveChanges();
                return RedirectToAction("Allfaqs");
            }
            return View(faq);
        }

        public async Task<IActionResult> EditFaq(int id)
        {
            var faq = await _context.Faqs.FindAsync(id);
            if (faq == null)
            {
                return NotFound();
            }
            return View(faq);
        }

        [HttpPost]
        public async Task<IActionResult> EditFaq(Faq faq)
        {
            if (ModelState.IsValid)
            {
                _context.Faqs.Update(faq);
                await _context.SaveChangesAsync();
                return RedirectToAction("AllFaqs");
            }
            return View(faq);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteFaq(int id)
        {
            var faq = await _context.Faqs.FindAsync(id);
            if (faq != null)
            {
                _context.Faqs.Remove(faq);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("AllFaqs");
        }
    }
}
