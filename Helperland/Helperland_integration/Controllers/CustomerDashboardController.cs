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


        public IActionResult customerDashboard(bool isServiceCancel = false, bool isUpdated = false, bool isPasswordUpdated = false, bool isReschedule = false)
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
            return RedirectToAction(nameof(customerDashboard), new { isReschedule = true });

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
            if (ModelState.IsValid)
            {
                bool update = _customerRepository.updateCustomerDetails(user, userId);
                return Json(new { detailsUpdate = true });
            }
            else
            {
                return View();
            }

        }

        public IActionResult customerPassword()
        {

            return View();
        }

        [HttpPost]
        public IActionResult customerPassword(ResetPasswordModel resetPasswordModel)
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if (ModelState.IsValid)
            {

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
            else
            {
                return View();
            }



        }

        public IActionResult customerAddress()
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            var addresses = _customerRepository.GetAddress(userId);
            return View(addresses);
        }




        [HttpGet]
        [Route("CustomerDashboard/addOrEditAddress/{addressId}")]
        public IActionResult addOrEditAddress(int addressId)
        {
            int addId = addressId;
            int id = (int)HttpContext.Session.GetInt32("userId");

            if (addId == 0)
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
        public IActionResult addOrEditAddress(UserAddressViewModel useraddressViewModel)
        {
            //int addId = addressId;
            int id = (int)HttpContext.Session.GetInt32("userId");

            if (useraddressViewModel.AddressId == 0)
            {
                if (ModelState.IsValid)
                {
                    bool add = _customerRepository.addNewAddress(useraddressViewModel, id);
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
                    bool update = _customerRepository.updateAddress(useraddressViewModel, id);
                    return Json(new { updateAddress = true });
                }
                else
                {
                    return View();
                }
            }

        }

        [HttpGet]
        [Route("CustomerDashboard/deleteAddress/{addressId}")]
        public IActionResult deleteAddress(int addressId)
        {
            UserAddressViewModel userAddressViewModel= _customerRepository.GetSingleAddress(addressId);
            return View(userAddressViewModel);
        }

        [HttpPost]
        public IActionResult deleteAddress(UserAddressViewModel userAddressViewModel)
        {
            bool delete = _customerRepository.deleteCutomerAddress(userAddressViewModel);
            return Json(new { addressDeleted = true });
        }

        public IActionResult RateSP([Bind("ServiceId", "SPId", "OnTimeArrival", "Friendly", "QualityOfService", "Comment")] RatingViewModel ratingViewModel)
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            Rating rating = new Rating()
            {
                ServiceRequestId = ratingViewModel.ServiceId,
                RatingDate = ratingViewModel.RatingDate,
                RatingFrom = userId,
                RatingTo = ratingViewModel.SPId,
                Comments = ratingViewModel.Comment,
                OnTimeArrival = ratingViewModel.OnTimeArrival,
                Friendly = ratingViewModel.Friendly,
                QualityOfService = ratingViewModel.QualityOfService,
                Ratings = (ratingViewModel.QualityOfService + ratingViewModel.Friendly + ratingViewModel.OnTimeArrival) / 3
            };

            bool ratingDone = _customerRepository.AddRating(rating);
            if (ratingDone)
                return Json(new { ratingSuccess = true });
            else
                return Json(false);
        }

    }
}
