using Helperland_integration.Models;
using Helperland_integration.Repository;
using Helperland_integration.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Helperland_integration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserRegistration _userRegistration = null;
        private readonly LoginRepository _loginRepository = null;
        private readonly ContactRepository _contactRepository = null;
        public HomeController(ILogger<HomeController> logger,UserRegistration userRegistration, LoginRepository loginRepository, ContactRepository contactRepository)
        {
            _logger = logger;
            _userRegistration = userRegistration;
            _loginRepository = loginRepository;
            _contactRepository = contactRepository;
        }

        public IActionResult index()
        {
            return View();
        }

        public IActionResult faq()
        {
            return View();
        }
        public IActionResult prices()
        {
            return View();
        }
        public IActionResult contact(bool isSuccess=false)
        {
            ViewBag.IsSuccess=isSuccess;
            return View();
        }

        [HttpPost]
        public IActionResult contact(ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                
                int id = _contactRepository.SendMessage(contactViewModel);
                if(id>0)
                {
                    return RedirectToAction(nameof(contact), new { isSuccess = true });
                }
            }
            return View();
        }
        public IActionResult about()
        {
            return View();
        }
        public IActionResult register(bool isSuccess = false,bool isExistEmail=false)
        {
            ViewBag.IsSuccess=isSuccess;
            ViewBag.IsExistEmail=isExistEmail;  
            return View();
        }

        [HttpPost]
        public IActionResult register(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                
                int id = _userRegistration.AddNewUser(userViewModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(register), new { isSuccess = true });
                }
                else if(id==-1)
                {
                    return RedirectToAction(nameof(register), new { isExistEmail = true });
                }
                else
                {
                    return RedirectToAction(nameof(register));
                }
            }
            else
            {
                return View();
            }  
        }

        public IActionResult HelperRegistration(bool isSuccess = false, bool isExistEmail = false)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.IsExistEmail = isExistEmail;
            return View();
        }

        [HttpPost]
        public IActionResult HelperRegistration(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {

                int id = _userRegistration.AddNewHelper(userViewModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(HelperRegistration), new { isSuccess = true });
                }
                else if (id == -1)
                {
                    return RedirectToAction(nameof(HelperRegistration), new { isExistEmail = true });
                }
                else
                {
                    return RedirectToAction(nameof(HelperRegistration));
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                
                bool isValidUser = _loginRepository.IsValidUser(loginViewModel);
                if (isValidUser)
                {
                    
                    return RedirectToAction("index");
                }
                else
                {
                    ViewBag.isOpen = true;
                   
                }
                

            }
           
            return View("index");

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
