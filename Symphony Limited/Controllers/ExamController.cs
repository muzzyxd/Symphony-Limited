using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Data;
using Symphony_Limited.Models;

namespace Symphony_Limited.Controllers
{
    public class ExamController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExamController(ApplicationDbContext context) { 

            _context = context;
        
        }

        public async Task<IActionResult> AllExams()
        {
            var examinations = await _context.Examinations.ToListAsync();
            return View(examinations);
        }
        public IActionResult AddExam()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddExam(Examination examination)
        {
            if (ModelState.IsValid)
            {
                await _context.Examinations.AddAsync(examination);
                _context.SaveChanges();
                return RedirectToAction("AllExams");
            }
            return View(examination);
        }


        public async Task<IActionResult> EditExam(int id)
        {
            var examination = await _context.Examinations.FindAsync(id);
            if (examination == null)
            {
                return NotFound();
            }
            return View(examination);
        }

        [HttpPost]
        public async Task<IActionResult> EditExam(Examination examination)
        {
            if (ModelState.IsValid)
            {
                _context.Examinations.Update(examination);
                await _context.SaveChangesAsync();
                return RedirectToAction("AllExams");
            }
            return View(examination);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var examination = await _context.Examinations.FindAsync(id);
            if (examination != null)
            {
                _context.Examinations.Remove(examination);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("AllExams");
        }
    }
}
