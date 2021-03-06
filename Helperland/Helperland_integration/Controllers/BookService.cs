using Helperland_integration.Models;
using Helperland_integration.Repository;
using Helperland_integration.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Helperland_integration.Controllers
{
    public class BookService : Controller
    {
        private readonly BookingRepository _bookingRepository;
        public BookService(BookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public IActionResult Index()
        {

            return View();
        }

     

        [HttpPost]
        public IActionResult CheckPincode(string pincode)
        {
            if(pincode == null)
            {
                return Json(new {pincodeEnter=true});
            }
            else if (pincode.Length != 6)
            {
                return Json(new { pincodeError = true });
            }
            else
            {
                if (_bookingRepository.IsServiceAvailable(pincode))
                {
                    return Json(new { pinAvailable = true, zipcode = pincode });
                }
                else
                    return Json(new { pinUnavailable = true });
            }
        }

     

        [HttpPost]
        public IActionResult AddAddress([FromBody] AddressViewModel addressViewModel)
        {
            if (addressViewModel.UserId != null && addressViewModel.AddressLine1 != null && addressViewModel.AddressLine2 != null && addressViewModel.City != null && addressViewModel.ZipCode != null)
            {
                if (_bookingRepository.SetAddress(addressViewModel))
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            else
            {
                return Json(false);
            }

        }
        public IActionResult GetAddress(string userID)
        {
            List<AddressViewModel> addresses = _bookingRepository.GetAddress(Int32.Parse(userID));
            if (addresses == null)
            {
                Json(false);
            }
            return Json(JsonConvert.SerializeObject(addresses));

        }
        [HttpPost]
        public IActionResult AddServiceRequest(BookServiceViewModel bookServiceViewModel)
        {
            int serviceId = _bookingRepository.addNewServiceRequest(bookServiceViewModel);
            UserAddress userAddress = _bookingRepository.getAddressForStore(bookServiceViewModel.AddressId);
            ServiceRequestAddress requestAddress = new ServiceRequestAddress()
            {
                ServiceRequestId = serviceId,
                AddressLine1 = userAddress.AddressLine1,
                AddressLine2 = userAddress.AddressLine2,
                City = userAddress.City,
                PostalCode = userAddress.PostalCode,
                Mobile = userAddress.Mobile,
                Email = userAddress.Email,
            };
           
            var add=_bookingRepository.saveServiceAddress(requestAddress);
            bool addES=_bookingRepository.addExtraService(bookServiceViewModel,serviceId);
            return Json(new { finalBooking = true });
        
        }

    }
}
