using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Data;
using Symphony_Limited.Migrations;
using Symphony_Limited.Models;

namespace Symphony_Limited.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {

            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var subject = await _context.Subjects.OrderByDescending(p => p.Subject_Id).ToListAsync();
            return View(subject);
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
        public async Task<IActionResult> About()
        {
            var abouts = await _context.Abouts.ToListAsync();
            return View(abouts);
        }

        public async Task<IActionResult> FAQS()
        {
            var faqs = await _context.Faqs.ToListAsync();
            return View(faqs);
        }

        public async Task<IActionResult> Branches()
        {
            var contact = await _context.Contacts.ToListAsync();
            return View(contact);
        }

        public async Task<IActionResult> EntranceExam()
        {
            var examinations = await _context.Examinations.ToListAsync();
            return View(examinations);
        }

        public IActionResult ExamResult(string rollNumber)
        {
            if (!string.IsNullOrEmpty(rollNumber))
            {
                var student = _context.Students.FirstOrDefault(s => s.RollNumber == rollNumber);

                if (student == null)
                {
                    ViewBag.Message = "Roll number not found."; // Set an error message
                }
                return View("ExamResult", student);
            }

            return View();
        }

        public  async Task<IActionResult> Courses()
        {
            var subject = await _context.Subjects.OrderByDescending(p => p.Subject_Id).ToListAsync();
            return View(subject);
        }


        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                await _context.Feedbacks.AddAsync(feedback);
                _context.SaveChanges();
                return RedirectToAction("Contact");
            }
            return View(feedback);
        }

    }
}
