using Helperland_integration.Repository;
using Helperland_integration.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Helperland_integration.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminRepository _adminRepository;

        public AdminController(AdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }


        public IActionResult adminAllService()
        {
            var serviceList = _adminRepository.getAllService();
            return View(serviceList);
        }

        public IActionResult UserManagement()
        {
            return View();
        }

        [HttpGet]
        [Route("Admin/editServiceRequest/{serviceId}")]
        public IActionResult editServiceRequest(int serviceId)
        {
            ServiceDetailsViewModel model = _adminRepository.getServiceDetails(serviceId);
            return View(model);
        }

        [HttpPost]
        public IActionResult editServiceRequest(ServiceDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool update = _adminRepository.updateService(model);
                return Json(new {serviceUpdated=true});
            }
            else
            {
                return View(model);
            }
        }
    }
}
