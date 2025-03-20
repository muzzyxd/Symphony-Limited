using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Data;
using Symphony_Limited.Models;

namespace Symphony_Limited.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {

            _context = context;

        }

        public async Task<IActionResult> AllStudents()
        {
            var student = await _context.Students.ToListAsync();
            return View(student);
        }

        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                await _context.Students.AddAsync(student);
                _context.SaveChanges();
                return RedirectToAction("AllStudents");
            }
            return View(student);
        }


        public async Task<IActionResult> EditStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("AllStudents");
            }
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("AllStudents");
        }

    }
}
