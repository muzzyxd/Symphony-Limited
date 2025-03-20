using Microsoft.AspNetCore.Mvc;

namespace Symphony_Limited.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
