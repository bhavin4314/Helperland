using Helperland_integration.Data;
using Helperland_integration.Models;
using Helperland_integration.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helperland_integration.Repository
{
    public class AdminRepository
    {
        private readonly HelperlandContext _helperlandContext;

        public AdminRepository(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        public IEnumerable<ServiceRequest> getAllService()
        {
            return _helperlandContext.ServiceRequests
                .Include(x => x.User)
                .Include(service => service.ServiceProvider)
                .ThenInclude(sp => sp.RatingRatingToNavigations).AsSplitQuery()
                .Include(y => y.ServiceRequestAddresses)
                .Where(x => x.Status != null).ToList();
        }

        public ServiceDetailsViewModel getServiceDetails(int serviceId)
        {
            ServiceRequestAddress serviceRequestAddress = _helperlandContext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == serviceId).FirstOrDefault();
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == serviceId).FirstOrDefault();
            
            ServiceDetailsViewModel model = new ServiceDetailsViewModel();
            model.ServiceId = serviceId;
            model.Date = @String.Format("{0:yyyy/MM/dd}", serviceRequest.ServiceStartDate);
            model.Time = (Convert.ToString(Convert.ToDateTime(serviceRequest.ServiceStartDate).TimeOfDay).Substring(0, 5));
            model.AddressLine1 = serviceRequestAddress.AddressLine2;
            model.AddressLine2 = serviceRequestAddress.AddressLine1;
            model.ZipCode = serviceRequestAddress.PostalCode;
            model.City = serviceRequestAddress.City;

            return model;
        }

        public bool updateService(ServiceDetailsViewModel model)
        {
            ServiceRequest serviceRequest = _helperlandContext.ServiceRequests.Where(x => x.ServiceRequestId == model.ServiceId).FirstOrDefault();
            ServiceRequestAddress serviceRequestAddress = _helperlandContext.ServiceRequestAddresses.Where(x => x.ServiceRequestId == model.ServiceId).FirstOrDefault();

            serviceRequest.ServiceStartDate = Convert.ToDateTime(model.Date + " " + model.Time);
            serviceRequestAddress.AddressLine1 = model.AddressLine2;
            serviceRequestAddress.AddressLine2 = model.AddressLine1;
            serviceRequestAddress.PostalCode = model.ZipCode;
            serviceRequestAddress.City = model.City;

            _helperlandContext.Update(serviceRequest);
            _helperlandContext.Update(serviceRequestAddress);
            _helperlandContext.SaveChanges();

            return true;
        }

    }
}
