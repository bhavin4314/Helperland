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


        public IActionResult customerDashboard(bool isServiceCancel=false,bool isUpdated = false, bool isPasswordUpdated = false,bool isReschedule=false)
        {
            ViewBag.IsUpdated = isUpdated;
            ViewBag.IsPasswordUpdated = isPasswordUpdated;
            ViewBag.IsReschedule = isReschedule;
            ViewBag.IsServiceCancel = isServiceCancel;

            int userId = (int)HttpContext.Session.GetInt32("userId");
            var service = _customerRepository.GetService(userId);
            return View(service);
        }
        [HttpGet]
        [Route("CustomerDashboard/serviceDetails/{serviceId}")]
        public IActionResult serviceDetails(int serviceId)
        {
            ServiceRequest serviceRequest = _customerRepository.GetServiceDetails(serviceId);
            return View(serviceRequest);
        }

        [HttpGet]
        [Route("CustomerDashboard/rescheduleService/{serviceId}")]
        public IActionResult rescheduleService(int serviceId)
        {
            BookServiceViewModel bookServiceViewModel = _customerRepository.getserviceDateTime(serviceId);
            return View(bookServiceViewModel);
        }

        [HttpPost]
        public IActionResult rescheduleService(BookServiceViewModel bookServiceViewModel)
        {
            bool update = _customerRepository.updateDateTime(bookServiceViewModel);
            //return Json(new { reScheduleDone = true });
            return RedirectToAction(nameof(customerDashboard),new { isReschedule = true } );

        }

        [HttpGet]
        [Route("CustomerDashboard/cancelService/{serviceId}")]
        public IActionResult cancelService(int serviceId)
        {
            ServiceRequest serviceRequest = _customerRepository.GetServiceDetails(serviceId);
            return View(serviceRequest);
        }

        [HttpPost]
        public IActionResult cancelService(ServiceRequest serviceRequest)
        {
            bool cancel = _customerRepository.cancelServiceRequest(serviceRequest);
            return RedirectToAction(nameof(customerDashboard), new { isServiceCancel = true });
        }

        public IActionResult customerServiceHistory()
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            var service = _customerRepository.GetServiceCancelComplete(userId);
            return View(service);
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
                return Json(new { passwordUpdate = true });

            }
            else
            {
                return Json(new { passworNotUpdate = true });
            }
           
        }

        public IActionResult customerAddress()
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            var addresses = _customerRepository.GetAddress(userId);
            return View(addresses);
        }

        //public IActionResult addNewAddress()
        //{
        //    return View("addOrEditAddress");
        //}
        //[HttpPost]
        //public IActionResult addNewAddress(AddressViewModel addressViewModel)
        //{
        //    int id = (int)HttpContext.Session.GetInt32("userId");
        //    if(ModelState.IsValid)
        //    {
        //        bool add = _customerRepository.addNewAddress(addressViewModel, id);
        //        //return RedirectToAction("customerAddress");
        //        return Json(new { addAddress = true });
        //    }
        //    else
        //    {
        //        return View();
        //    }
            
        //} 


        [HttpGet]
        [Route("CustomerDashboard/addOrEditAddress/{addressId}")]
        public IActionResult addOrEditAddress(int addressId)
        {
            int addId = addressId;
            int id = (int)HttpContext.Session.GetInt32("userId");

            if(addId== 0)
            {
                UserAddressViewModel userAddressViewModel = new UserAddressViewModel();
                return View(userAddressViewModel);
            }
            else
            {
                UserAddressViewModel userAddress = _customerRepository.GetSingleAddress(addId);
                return View(userAddress);
            }
           
        }
        [HttpPost]
        public IActionResult addOrEditAddress(AddressViewModel addressViewModel)
        {
            //int addId = addressId;
            int id = (int)HttpContext.Session.GetInt32("userId");
            
            if(addressViewModel.AddressId==0)
            {
                if (ModelState.IsValid)
                {
                    bool add = _customerRepository.addNewAddress(addressViewModel, id);
                    //return RedirectToAction("customerAddress");
                    return Json(new { addAddress = true });
                }
                else
                {
                    return View();
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    bool update = _customerRepository.updateAddress(addressViewModel, id);
                    return Json(new { updateAddress = true });
                }
                else
                {
                    return View();
                }
            }
            
        }
    }
}
