using Helperland_integration.Data;
using Helperland_integration.Models;
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
            return true;
        }

        public IEnumerable<ServiceRequest> getServiceHistory(int userId)
        {
            return _helperlandContext.ServiceRequests
                .Include(service => service.User)
                .Include(service => service.ServiceRequestAddresses)
                .Where(x => x.Status == 3 && x.ServiceProviderId == userId).ToList();
        }
    }
}
