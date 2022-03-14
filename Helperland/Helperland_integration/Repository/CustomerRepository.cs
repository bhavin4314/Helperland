using Helperland_integration.Data;
using Helperland_integration.Models;
using Helperland_integration.ViewModel;
using Microsoft.AspNetCore.Http;
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

    }
}
