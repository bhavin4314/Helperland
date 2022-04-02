using Helperland_integration.Data;
using Helperland_integration.Models;
using Helperland_integration.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helperland_integration.Repository
{
    public class HelperRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public HelperRepository(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public IEnumerable<ServiceRequest> getNewService()
        {
            return _helperlandContext.ServiceRequests
                .Include(service => service.User)
                .Include(service => service.ServiceRequestAddresses)
                .AsSplitQuery()
                .Where(x => x.Status == 1).ToList();
             
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
        public IEnumerable<ServiceRequest> getUpcomingService(int userId)
        {
            return _helperlandContext.ServiceRequests
                .Include(service => service.User)
                .Include(service => service.ServiceRequestAddresses)
                .Where(x => x.Status == 4 && x.ServiceProviderId==userId).ToList();
        }
        public bool acceptRequest(int spId,int serviceId)
        {
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serviceId).FirstOrDefault();
            serviceRequest.Status = 4;
            serviceRequest.SpacceptedDate = DateTime.Now;
            serviceRequest.ServiceProviderId = spId;
            _helperlandContext.ServiceRequests.Update(serviceRequest);
            _helperlandContext.SaveChanges();

            return true;
        }

        public bool cancelServiceRequest(ServiceRequest serviceRequest)
        {
            ServiceRequest serviceRequest1 = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serviceRequest.ServiceRequestId).FirstOrDefault();
            serviceRequest1.Status = 1;
            _helperlandContext.Update(serviceRequest1);
            _helperlandContext.SaveChanges();
            return true;
        }

        public bool completedService(int serviceId)
        {
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serviceId).FirstOrDefault();
            serviceRequest.Status = 3;
            _helperlandContext.Update(serviceRequest);
            _helperlandContext.SaveChanges();

            int favAndBlockCount = _helperlandContext.FavoriteAndBlockeds.Where(x => x.UserId == serviceRequest.ServiceProviderId && x.TargetUserId == serviceRequest.UserId).Count();
            if (favAndBlockCount == 0)
            {
                FavoriteAndBlocked blockBySp = new FavoriteAndBlocked()
                {
                    UserId = serviceRequest.UserId,
                    TargetUserId = (int)serviceRequest.ServiceProviderId,
                    IsBlocked = false,
                    IsFavorite = false,
                };
                
                _helperlandContext.FavoriteAndBlockeds.Add(blockBySp);
                _helperlandContext.SaveChanges();
            }

            return true;
        }

        public IEnumerable<ServiceRequest> getServiceHistory(int userId)
        {
            return _helperlandContext.ServiceRequests
                .Include(service => service.User)
                .Include(service => service.ServiceRequestAddresses)
                .Where(x => x.Status == 3 && x.ServiceProviderId == userId).ToList();
        }

        public spDetailsViewModel getHelperDetails(int userId)
        {
            User user = _helperlandContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            UserAddress userAddress = _helperlandContext.UserAddresses.Where(y => y.UserId == userId).FirstOrDefault();
            spDetailsViewModel spDetails = new spDetailsViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                MobileNo = user.Mobile,
                DateOfBirth = user.DateOfBirth,
                NationalityId = user.NationalityId ,
                Gender = user.Gender ?? 0,
                Avatar = user.UserProfilePicture
            };

            if(userAddress != null)
            {
                spDetails.AddressLine1 = userAddress.AddressLine1;
                spDetails.AddressLine2 = userAddress.AddressLine2;
                spDetails.ZipCode = userAddress.PostalCode;
                spDetails.City = userAddress.City;
            }

            return spDetails;    
        }

        public bool spDetailUpdate(spDetailsViewModel spDetails,int userId)
        {
            User user = _helperlandContext.Users.Where(x => x.UserId == userId).FirstOrDefault();
            UserAddress userAddress = _helperlandContext.UserAddresses.Where(y => y.UserId == userId).FirstOrDefault();
            user.FirstName=spDetails.FirstName;
            user.LastName=spDetails.LastName;
            user.Email=spDetails.Email;
            user.Mobile = spDetails.MobileNo;
            user.DateOfBirth=spDetails.DateOfBirth;
            user.NationalityId=spDetails.NationalityId;
            user.Gender = spDetails.Gender;
            user.UserProfilePicture = spDetails.Avatar;
            user.ModifiedDate=DateTime.Now;
            _helperlandContext.Users.Update(user);
            //_helperlandContext.SaveChanges();

            if(userAddress!=null)
            {
                userAddress.UserId = userId;
                userAddress.AddressLine1=spDetails.AddressLine1;
                userAddress.AddressLine2=spDetails.AddressLine2;
                userAddress.PostalCode = spDetails.ZipCode;
                userAddress.City = spDetails.City;
                _helperlandContext.Update(userAddress);
                //_helperlandContext.SaveChanges();
            }
            else
            {
                UserAddress userAddress1 = new UserAddress();
                userAddress1.UserId = userId;
                userAddress1.AddressLine1 = spDetails.AddressLine1;
                userAddress1.AddressLine2 = spDetails.AddressLine2;
                userAddress1.PostalCode = spDetails.ZipCode;
                userAddress1.City = spDetails.City;
                _helperlandContext.Add(userAddress1);
                
            }
            _helperlandContext.SaveChanges();
            return true;
        }

        public bool passwordUpdate(ResetPasswordModel resetPasswordModel, int? id)
        {
            User user = _helperlandContext.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user.Password != resetPasswordModel.CurrentPassword)
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

        public IEnumerable<Rating> SpRatings(int spId)
        {
            return _helperlandContext.Ratings.Include(x => x.RatingFromNavigation)
                                    .Include(y => y.ServiceRequest).AsSplitQuery()
                                    .Where(r => r.RatingTo == spId).ToList();
        }

        
    }
}
