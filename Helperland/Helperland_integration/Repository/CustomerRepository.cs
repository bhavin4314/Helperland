using Helperland_integration.Data;
using Helperland_integration.Models;
using Helperland_integration.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helperland_integration.Repository
{
    public class CustomerRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public CustomerRepository(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        public IEnumerable<ServiceRequest> GetService(int id)
        {
            return _helperlandContext.ServiceRequests.Where(x => x.UserId == id && x.Status==1).ToList();
        }
       
        public ServiceRequest GetServiceDetails(int serviceId)
        {
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Include(service => service.ServiceProvider)
                                            .Include(service => service.User)
                                            .Include(service => service.ServiceRequestAddresses).AsSplitQuery()
                                            .Include(service => service.ServiceRequestExtras).AsSplitQuery()
                                            .Where(x => x.ServiceRequestId == serviceId).FirstOrDefault();
            return serviceRequest;
        }

        public User GetCustomer(int? id)
        {
            User user = _helperlandContext.Users.Where(x => x.UserId == id).FirstOrDefault();
            return user;
        }   

        public bool updateCustomerDetails(User user,int? id)
        {
            //user.UserId = (int)id;
            User user1 = _helperlandContext.Users.Where(x => x.UserId == id).FirstOrDefault();
            user1.ModifiedDate = DateTime.Now;
            user1.FirstName = user.FirstName;
            user1.LastName = user.LastName; 
            user1.Email = user.Email;   
            user1.Mobile= user.Mobile;
            user1.DateOfBirth = user.DateOfBirth;
            user1.CreatedDate=user.CreatedDate;
            _helperlandContext.Users.Update(user1);
            _helperlandContext.SaveChanges();
            return true;
        }

        public bool passwordUpdate(ResetPasswordModel resetPasswordModel, int? id)
        {
            User user=_helperlandContext.Users.Where(x=>x.UserId==id).FirstOrDefault();
            if(user.Password!=resetPasswordModel.CurrentPassword)
            {
                return false;
            }
            else
            {
                user.Password = resetPasswordModel.Password;
                _helperlandContext.Users.Update(user);
                _helperlandContext.SaveChanges();
                return true;
            }
           
        }

        public IEnumerable<UserAddress> GetAddress(int id)
        {
            return _helperlandContext.UserAddresses.Where(x => x.UserId == id).ToList();
        }
        public UserAddressViewModel GetSingleAddress(int addId) 
        {
            UserAddress userAddress = _helperlandContext.UserAddresses.Where(x => x.AddressId == addId).FirstOrDefault();
            UserAddressViewModel userAddressViewModel = new UserAddressViewModel();
            userAddressViewModel.AddressId = addId;
            userAddressViewModel.AddressLine1= userAddress.AddressLine2;
            userAddressViewModel.AddressLine2 = userAddress.AddressLine1;
            userAddressViewModel.ZipCode = userAddress.PostalCode;
            userAddressViewModel.City = userAddress.City;
            userAddressViewModel.MobileNo = userAddress.Mobile;

            return userAddressViewModel;
        }

        public bool addNewAddress(UserAddressViewModel useraddressViewModel,int id)
        {
        
            UserAddress userAddress = new UserAddress();
            userAddress.UserId = id;
            userAddress.AddressLine1 = useraddressViewModel.AddressLine2;
            userAddress.AddressLine2 = useraddressViewModel.AddressLine1;
            userAddress.City = useraddressViewModel.City;
            userAddress.PostalCode = useraddressViewModel.ZipCode;
            userAddress.Mobile = useraddressViewModel.MobileNo;
            //userAddress.Email = "shyam@gmail.com";
            _helperlandContext.UserAddresses.Add(userAddress);
            _helperlandContext.SaveChanges();
            return true;

        }

        public bool updateAddress(UserAddressViewModel useraddressViewModel, int id)
        {
            UserAddress userAddress = _helperlandContext.UserAddresses.Where(x => x.AddressId == useraddressViewModel.AddressId).FirstOrDefault();
            userAddress.UserId = id;
            userAddress.AddressLine1 = useraddressViewModel.AddressLine2;
            userAddress.AddressLine2 = useraddressViewModel.AddressLine1;
            userAddress.City = useraddressViewModel.City;
            userAddress.PostalCode = useraddressViewModel.ZipCode;
            userAddress.Mobile = useraddressViewModel.MobileNo;
            _helperlandContext.UserAddresses.Update(userAddress);
            _helperlandContext.SaveChanges();
            return true;
        }

        public BookServiceViewModel getserviceDateTime(int serviceId)
        {
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serviceId).FirstOrDefault();
            BookServiceViewModel bookServiceViewModel = new BookServiceViewModel();
            bookServiceViewModel.Date = @String.Format("{0:dd/MM/yyyy}", serviceRequest.ServiceStartDate);
            bookServiceViewModel.Time = (Convert.ToString(Convert.ToDateTime(serviceRequest.ServiceStartDate).TimeOfDay).Substring(0, 5));
            bookServiceViewModel.serviceId = serviceRequest.ServiceRequestId;
            return bookServiceViewModel;
        }

        public bool updateDateTime(BookServiceViewModel bookServiceViewModel)
        {
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == bookServiceViewModel.serviceId).FirstOrDefault();
            serviceRequest.ServiceStartDate = Convert.ToDateTime(bookServiceViewModel.Date + " " + bookServiceViewModel.Time.ToString()); ;
            _helperlandContext.ServiceRequests.Update(serviceRequest);
            _helperlandContext.SaveChanges();
            return true;
        }

        public bool cancelServiceRequest(ServiceRequest serviceRequest)
        {
            ServiceRequest serviceRequest1 = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serviceRequest.ServiceRequestId).FirstOrDefault();
            serviceRequest1.Status = 2;
            serviceRequest1.Comments = serviceRequest.Comments;
            _helperlandContext.Update(serviceRequest1);
            _helperlandContext.SaveChanges();
            return true;
        }

        public IEnumerable<ServiceRequest> GetServiceCancelComplete(int id)
        {
            return _helperlandContext.ServiceRequests.Where(x => x.UserId == id && x.Status == 2).ToList();
        }

        public bool deleteCutomerAddress(UserAddressViewModel userAddressViewModel)
        {
            UserAddress userAddress = _helperlandContext.UserAddresses.Where(x => x.AddressId == userAddressViewModel.AddressId).FirstOrDefault();
            _helperlandContext.UserAddresses.Remove(userAddress);
            _helperlandContext.SaveChanges();
            return true;
        }
    }
}
