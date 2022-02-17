using Helperland_integration.Data;
using Helperland_integration.Models;
using Helperland_integration.ViewModel;
using System;
using System.Linq;

namespace Helperland_integration.Repository
{
    public class UserRegistration
    {
        private readonly HelperlandContext _helperlandContext = null;
        public UserRegistration(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }
        public int AddNewUser(UserViewModel userViewModel)
        {
            bool isEmailAlreadyExists = _helperlandContext.Users.Any(x => x.Email == userViewModel.Email);
            if (isEmailAlreadyExists==false)
            {
                User newUser = new User();
                newUser.FirstName = userViewModel.FirstName;
                newUser.LastName = userViewModel.LastName;
                newUser.Email = userViewModel.Email;
                newUser.Mobile = userViewModel.Mobile;
                newUser.Password = userViewModel.Password;
                newUser.CreatedDate = DateTime.Now.Date;
                newUser.ModifiedDate = DateTime.Now.Date;
                newUser.UserTypeId = 1;
                _helperlandContext.Users.Add(newUser);
                _helperlandContext.SaveChanges();
                return newUser.UserId;
            }
            else
            {
                return -1;
            }
        
        }

        public int AddNewHelper (UserViewModel userViewModel)
        {
            bool isEmailAlreadyExists = _helperlandContext.Users.Any(x => x.Email == userViewModel.Email);
            if (isEmailAlreadyExists == false)
            {
                User newUser = new User();
                newUser.FirstName = userViewModel.FirstName;
                newUser.LastName = userViewModel.LastName;
                newUser.Email = userViewModel.Email;
                newUser.Mobile = userViewModel.Mobile;
                newUser.Password = userViewModel.Password;
                newUser.CreatedDate = DateTime.Now.Date;
                newUser.ModifiedDate = DateTime.Now.Date;
                newUser.UserTypeId = 2;
                _helperlandContext.Users.Add(newUser);
                _helperlandContext.SaveChanges();
                return newUser.UserId;
            }
            else
            {
                return -1;
            }

        }
    }
}
