using Helperland_integration.Models;
using Helperland_integration.Repository;
using Helperland_integration.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Helperland_integration.Controllers
{
    public class ServiceProvider : Controller
    {
        private readonly HelperRepository _helperRepository;
        public ServiceProvider(HelperRepository helperRepository)
        {
            _helperRepository = helperRepository;
        }
        public IActionResult spNewService(bool isServiceAccepted=false,bool isServiceCancel=false,bool isCompleted=false)
        {
            ViewBag.IsServiceAccepted = isServiceAccepted;
            ViewBag.IsServiceCancel = isServiceCancel;
            ViewBag.IsCompleted = isCompleted;  
            //int id = (int)HttpContext.Session.GetInt32("userId");
            var newServices = _helperRepository.getNewService();
            return View(newServices);
        }

        [HttpGet]
        [Route("ServiceProvider/serviceDetailsModal/{serviceId}")]
        public IActionResult serviceDetailsModal(int serviceId)
        {
            ServiceRequest serviceRequest = _helperRepository.GetServiceDetails(serviceId);
            return View(serviceRequest);
        }

        [HttpPost]
        public IActionResult serviceAccept(int serviceId)
        {
            int spId = (int)HttpContext.Session.GetInt32("userId");
            bool accept = _helperRepository.acceptRequest(spId, serviceId);
            return RedirectToAction(nameof(spNewService), new { isServiceAccepted =true});
            //return Json(new { serviceAccepted = true });
        }


        public IActionResult upcomingService()
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            var upcomingServices = _helperRepository.getUpcomingService(userId);
            return View(upcomingServices);
        }

       
        
        [HttpGet]
        [Route("ServiceProvider/cancelServiceBySp/{serviceId}")]
        public IActionResult cancelServiceBySp(int serviceId)
        {
            ServiceRequest serviceRequest = _helperRepository.GetServiceDetails(serviceId);
            return View(serviceRequest);
        }

        [HttpPost]
        public IActionResult cancelServiceBySp(ServiceRequest serviceRequest)
        {
            bool cancel = _helperRepository.cancelServiceRequest(serviceRequest);
            return RedirectToAction(nameof(spNewService), new { isServiceCancel = true });
        }

        [HttpPost]
        public IActionResult completeService(int serviceId)
        {
            bool complete = _helperRepository.completedService(serviceId);
            return RedirectToAction(nameof(spNewService), new { isCompleted = true });
        }

        public IActionResult serviceHistory() 
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            var serviceHistorySp = _helperRepository.getServiceHistory(userId);
            return View(serviceHistorySp);
        }
        
        [HttpGet]
        public IActionResult spDetails()
        {
            int userId = (int) HttpContext.Session.GetInt32("userId");
            spDetailsViewModel spDetails = _helperRepository.getHelperDetails(userId);
            return View(spDetails);
        }
        [HttpPost]
        public IActionResult spDetails(spDetailsViewModel spDetails)
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            if (ModelState.IsValid)
            {
                bool update = _helperRepository.spDetailUpdate(spDetails,userId);
                return Json(new { spDetailsUpdate = true });
            }
            else
            {
                return View();
            }
            
        }


        public IActionResult spPassword()
        {
            return View();
        }
     
        [HttpPost]
        public IActionResult spPassword(ResetPasswordModel resetPasswordModel)
        {
            int? userId = HttpContext.Session.GetInt32("userId");
            if (ModelState.IsValid)
            {

                bool update = _helperRepository.passwordUpdate(resetPasswordModel, userId);
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

        public IActionResult myRatingSP()
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            var ratingList = _helperRepository.SpRatings(userId);
            return View(ratingList);
        }

        public IActionResult blockCustomer()
        {
            int userId = (int)HttpContext.Session.GetInt32("userId");
            return View();
        }
    }
}
