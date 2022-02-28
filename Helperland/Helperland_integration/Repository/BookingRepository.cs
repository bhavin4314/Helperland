using Helperland_integration.Data;
using Helperland_integration.Models;
using Helperland_integration.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helperland_integration.Repository
{
    public class BookingRepository
    {
        private readonly HelperlandContext _helperlandContext;
        public BookingRepository(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        public bool IsServiceAvailable(string Pincode)
        {
            Zipcode zipcode = _helperlandContext.Zipcodes.Where(x => x.ZipcodeValue == Pincode).FirstOrDefault();
            if (zipcode == null) 
            {
                return false;    
            }
            else
            {
                return true;
            }
        }



        public Boolean SetAddress(AddressViewModel addressViewModel)
        {
            //City city = _helperlandContext.Cities.Where(x => x.Id == addressViewModel.CityId).FirstOrDefault();

            UserAddress userAddress = new UserAddress();
            userAddress.UserId = 24;
            userAddress.AddressLine1 = addressViewModel.AddressLine1;
            userAddress.AddressLine2 = addressViewModel.AddressLine2;
            userAddress.City = addressViewModel.City;
            userAddress.PostalCode = addressViewModel.ZipCode;
            userAddress.Mobile = addressViewModel.MobileNo;
            userAddress.Email = "shyam@gmail.com";
            _helperlandContext.UserAddresses.Add(userAddress);
            _helperlandContext.SaveChanges();
            return true;
          
        }

        public List<AddressViewModel> GetAddress(int userID)
        {
       
                List<AddressViewModel> addresses = new List<AddressViewModel>();
                List<UserAddress> userAddress = _helperlandContext.UserAddresses.Where(x => x.UserId == userID).ToList();
                foreach (var item in userAddress)
                {
                    AddressViewModel addressViewModel = new AddressViewModel();
                //addressViewModel.UserId = userID;
                    addressViewModel.AddressId = item.AddressId;
                    addressViewModel.AddressLine1 = item.AddressLine2;
                    addressViewModel.AddressLine2 = item.AddressLine1;
                    addressViewModel.ZipCode = item.PostalCode;
                    addressViewModel.MobileNo = item.Mobile;
                    addresses.Add(addressViewModel);
                }
                return addresses;

        }

        public int addServiceRequest(BookServiceViewModel bookServiceViewModel)
        {

            ServiceRequest serviceRequest = new ServiceRequest();
            serviceRequest.UserId = 24;
            serviceRequest.ServiceStartDate = Convert.ToDateTime(bookServiceViewModel.Date + " " + bookServiceViewModel.Time.ToString());
            serviceRequest.ServiceHours = bookServiceViewModel.ServiceHours;
            serviceRequest.ZipCode = bookServiceViewModel.Zipcode;
            serviceRequest.Comments = bookServiceViewModel.Comments;
            serviceRequest.HasPets = bookServiceViewModel.HasPets;
            serviceRequest.CreatedDate = DateTime.Now;
            _helperlandContext.ServiceRequests.Add(serviceRequest);
            _helperlandContext.SaveChanges();
            return serviceRequest.ServiceRequestId;
        }


        public UserAddress getAddressForStore(int id)
        {
            return _helperlandContext.UserAddresses.Find(id);
        }

        public bool saveServiceAddress(ServiceRequestAddress requestAddress)
        {
            _helperlandContext.ServiceRequestAddresses.Add(requestAddress);
            _helperlandContext.SaveChanges();
            return true;
            //return requestAddress.ServiceRequestId;
        }

    }
}
