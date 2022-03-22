//using Helperland_integration.Repository;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Helperland_integration.Controllers
//{
//    public class ServiceProvider : Controller
//    {
//        private readonly HelperRepository _helperRepository;
//        public ServiceProvider(HelperRepository helperRepository)
//        {
//            _helperRepository = helperRepository;
//        }
//        public IActionResult spNewService()
//        {
//            //int id = (int)HttpContext.Session.GetInt32("userId");
//            var newService = _helperRepository.gethelper();
//            return View();
//        }
//    }
//}
