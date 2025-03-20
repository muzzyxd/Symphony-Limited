using Microsoft.AspNetCore.Mvc;
using Symphony_Limited.Data;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Symphony_Limited.Controllers
{
    public class CourseController : Controller
    {
            private readonly ApplicationDbContext _context;

            public CourseController(ApplicationDbContext context)
            {
                _context = context;
            }

        public async Task<IActionResult> ShowCourse()
        {
            var courses = await _context.Courses.ToListAsync();
            return View(courses);
        }

        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                await _context.Courses.AddAsync(course);
                _context.SaveChanges();
                return RedirectToAction("ShowCourse");
            }
            return View(course);
        }

        public async Task<IActionResult> EditCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return RedirectToAction("ShowCourse");
            }
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("ShowCourse");
        }

        public async Task<IActionResult> AddTopic()
        {
            ViewData["CourseId"] = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "CourseName");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTopic([Bind("TopicId,TopicName,CourseId")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ShowCourse));
            }
            ViewData["CourseId"] = new SelectList(await _context.Courses.ToListAsync(), "CourseId", "CourseName", topic.CourseId);
            return View(topic);
        }
    }
}