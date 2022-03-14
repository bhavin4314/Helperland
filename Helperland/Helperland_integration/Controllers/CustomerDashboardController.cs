using Helperland_integration.Models;
using Helperland_integration.Repository;
using Helperland_integration.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helperland_integration.Controllers
{
    public class CustomerDashboardController : Controller
    {
        private readonly CustomerRepository _customerRepository;
        public CustomerDashboardController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public IActionResult customerDashboard(bool isUpdated = false, bool isPasswordUpdated = false)
        {
            ViewBag.IsUpdated = isUpdated;
            ViewBag.IsPasswordUpdated = isPasswordUpdated;
            return View();
        }
        public IActionResult customerServiceHistory()
        {
            return View();
        }
        public IActionResult customerDetails()
        {
              
            int? userId = HttpContext.Session.GetInt32("userId");
            User user = _customerRepository.GetCustomer(userId);
            return View(user);
            
        }
        [HttpPost]
        public IActionResult customerDetails(User user)
        {
                int? userId = HttpContext.Session.GetInt32("userId");
                bool update = _customerRepository.updateCustomerDetails(user, userId);
            //return RedirectToAction("customerDashboard", new { isUpdated = true });
            //ModelState.AddModelError("", "Your details successfully updated.");
            return Json(new { detailsUpdate = true });
        }
        public IActionResult customerAddress()
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            var addresses = _customerRepository.GetAddress(userId);
            return View(addresses);
        }
        public IActionResult customerPassword()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult customerPassword(ResetPasswordModel resetPasswordModel)
            {
            int? userId = HttpContext.Session.GetInt32("userId");
            bool update = _customerRepository.passwordUpdate(resetPasswordModel, userId);
            if (update)
            {
                //ModelState.AddModelError("", "Your password successfully updated.");
                return Json(new { passwordUpdate = true });
                //return RedirectToAction("customerDashboard", new { isPasswordUpdated = true });

            }
            else
            {
                //ModelState.AddModelError("", "Your password successfully not updated.");
                return Json(new { passworNotUpdate = true });
                //return RedirectToAction("customerDashboard");
            }
           
        }
        //[HttpGet]
        //[Route("CustomerDashboard/addOrEditAddress/{addressId}")]
        public IActionResult addOrEditAddress()
        {
            //int id = (int)HttpContext.Session.GetInt32("userId");
            return View();
        }

    }
}
