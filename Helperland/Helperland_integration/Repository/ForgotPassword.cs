using Helperland_integration.Data;
using Helperland_integration.Models;
using Helperland_integration.ViewModel;
using System;
using System.Linq;

namespace Helperland_integration.Repository
{
    public class ForgotPassword
    {
        private readonly HelperlandContext _helperlandContext = null;

        public ForgotPassword(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }


        public bool IsUserExist(ForgotPasswordmodel forgotPasswordmodel)
        {
            bool isCheckemail = _helperlandContext.Users.Any(x => x.Email == forgotPasswordmodel.Email);
            return isCheckemail;
        }
        public int getUserId(string Email)
        {
            User user = _helperlandContext.Users.Where(x => x.Email == Email).FirstOrDefault();
            return user.UserId;
        }
        public bool resetThePassword(ResetPasswordModel resetPasswordModel)
        {
            User user = _helperlandContext.Users.Find(resetPasswordModel.UserId);
            
            user.Password = resetPasswordModel.Password;
            user.ModifiedDate= DateTime.Now.Date;
            _helperlandContext.Users.Update(user);
            _helperlandContext.SaveChanges();

            return true;    
        }
    }
}
