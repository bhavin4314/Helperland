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

        [HttpGet]
        public IActionResult AddressView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckPincode(string pincode)
        {
            if (pincode.Length != 6)
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

        //[HttpPost]
        //public IActionResult saveAddress(AddressViewModel addressViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _bookingRepository.setAddress(addressViewModel);
        //        return Json(new { address = true });
        //    }
        //    else
        //    {
        //        return Json(new { addressNot = true });
        //    }

        //}




        //[HttpPost]
        //public JsonResult CheckPincode(string Pincode)
        //{
        //    if (Pincode.Length != 6)
        //    {
        //        return Json(false);
        //    }
        //    else
        //    {
        //        if (_bookingRepository.IsServiceAvailable(Pincode))
        //        {
        //            return Json(true);
        //        }
        //        else
        //            return Json("We are not providing service in this area. We’ll notify you if any helper would start working near your area.");
        //    }
        //}



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
            int serviceId = _bookingRepository.addServiceRequest(bookServiceViewModel);
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
            return Json(new { finalBooking = true });
        }

    }
}
