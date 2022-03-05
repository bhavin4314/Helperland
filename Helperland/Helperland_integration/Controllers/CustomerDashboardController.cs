using Microsoft.AspNetCore.Mvc;

namespace Helperland_integration.Controllers
{
    public class CustomerDashboardController : Controller
    {
        public IActionResult CustomerDashboard()
        {
            return View();
        }
        public IActionResult CustomerServiceHistory()
        {
            return View();
        }
        public IActionResult customerDetails()
        {
            return View();
        }
        public IActionResult customerAddress()
        {
            return View();
        }
        public IActionResult customerPassword()
        {
            return View();
        }
    }
}
