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
            //userAddress.UserId = 24;
            userAddress.UserId = addressViewModel.UserId;
            userAddress.AddressLine1 = addressViewModel.AddressLine1;
            userAddress.AddressLine2 = addressViewModel.AddressLine2;
            userAddress.City = addressViewModel.City;
            userAddress.PostalCode = addressViewModel.ZipCode;
            userAddress.Mobile = addressViewModel.MobileNo;
            //userAddress.Email = "shyam@gmail.com";
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

        public int addNewServiceRequest(BookServiceViewModel bookServiceViewModel)
        {
            int ES = 0;
            ES = bookServiceViewModel.ExtraService1 ? ES + 1 : ES + 0;
            ES = bookServiceViewModel.ExtraService2 ? ES + 1 : ES + 0;
            ES = bookServiceViewModel.ExtraService3 ? ES + 1 : ES + 0;
            ES = bookServiceViewModel.ExtraService4 ? ES + 1 : ES + 0;
            ES = bookServiceViewModel.ExtraService5 ? ES + 1 : ES + 0;

            ServiceRequest serviceRequest = new ServiceRequest()
            {
                UserId = bookServiceViewModel.userId,

                ServiceStartDate = Convert.ToDateTime(bookServiceViewModel.Date + " " + bookServiceViewModel.Time.ToString()),
                ServiceHours = bookServiceViewModel.ServiceHours,
                ZipCode = bookServiceViewModel.Zipcode,
                Comments = bookServiceViewModel.Comments,
                HasPets = bookServiceViewModel.HasPets,
                CreatedDate = DateTime.Now,
                
                Status = 1,
                ExtraHours = ES * 0.5,
                ServiceHourlyRate = 18,
                SubTotal = Convert.ToDecimal((bookServiceViewModel.ServiceHours + (ES * 0.5)) * 18),
                TotalCost = Convert.ToDecimal((bookServiceViewModel.ServiceHours + (ES * 0.5)) * 18)
            };
            //serviceRequest.UserId = bookServiceViewModel.userId;
            
            //serviceRequest.ServiceStartDate = Convert.ToDateTime(bookServiceViewModel.Date + " " + bookServiceViewModel.Time.ToString());
            //serviceRequest.ServiceHours = bookServiceViewModel.ServiceHours;
            //serviceRequest.ZipCode = bookServiceViewModel.Zipcode;
            //serviceRequest.Comments = bookServiceViewModel.Comments;
            //serviceRequest.HasPets = bookServiceViewModel.HasPets;
            //serviceRequest.CreatedDate = DateTime.Now;
            //serviceRequest.ServiceHours = bookServiceViewModel.ServiceHours;
            //serviceRequest.Status = 1;
            //serviceRequest.ExtraHours = ES * 0.5;
            //serviceRequest.ServiceHourlyRate = 18;
            //serviceRequest.SubTotal = Convert.ToDecimal((bookServiceViewModel.ServiceHours + (ES * 0.5)) * 18);
            //serviceRequest.TotalCost = Convert.ToDecimal((bookServiceViewModel.ServiceHours + (ES * 0.5)) * 18);
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

        public bool addExtraService(BookServiceViewModel bookServiceViewModel,int id)
        {
    
          
            if (bookServiceViewModel.ExtraService1)
            {
                _helperlandContext.ServiceRequestExtras.Add(new ServiceRequestExtra() { ServiceRequestId=id,ServiceExtraId = 1 });
            }
            if (bookServiceViewModel.ExtraService2)
            {
                _helperlandContext.ServiceRequestExtras.Add(new ServiceRequestExtra() { ServiceRequestId = id, ServiceExtraId = 2 });
            }
            if (bookServiceViewModel.ExtraService3)
            {
                _helperlandContext.ServiceRequestExtras.Add(new ServiceRequestExtra() { ServiceRequestId = id, ServiceExtraId = 3 });
            }
            if (bookServiceViewModel.ExtraService4)
            {
                _helperlandContext.ServiceRequestExtras.Add(new ServiceRequestExtra() { ServiceRequestId = id, ServiceExtraId = 4 });

            }
            if (bookServiceViewModel.ExtraService5)
            {
                _helperlandContext.ServiceRequestExtras.Add(new ServiceRequestExtra() { ServiceRequestId = id, ServiceExtraId = 5 });
                //_helperlandContext.SaveChanges();
            }
            _helperlandContext.SaveChanges();

            return true;
        }
    }
}
