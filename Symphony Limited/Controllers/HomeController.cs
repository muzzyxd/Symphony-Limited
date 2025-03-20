using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Symphony_Limited.Data;
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
            var contact = await _context.Contacts.ToListAsync();
            return View(contact);
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
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult FAQS()
        {
            return View();
        }
    }
}
