using Helperland_integration.Data;
using Helperland_integration.Models;
using Helperland_integration.ViewModel;
using System.Linq;

namespace Helperland_integration.Repository
{
    public class LoginRepository
    {
        private readonly HelperlandContext _helperlandContext = null;

        public LoginRepository(HelperlandContext helperlandContext)
        {
            _helperlandContext = helperlandContext;
        }

        public int IsValidUser(LoginViewModel loginViewModel)
        {
            //bool isCheckUser = _helperlandContext.Users.Any(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);
            //return isCheckUser;

            User user = _helperlandContext.Users.Where(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password).FirstOrDefault();
            if(user != null)
            {
                return user.UserId;
            }
            else
            {
                return 0;
            }
        }   
        public bool IsUserExist(LoginViewModel loginViewModel)
        {
            bool isCheckemail = _helperlandContext.Users.Any(x => x.Email == loginViewModel.Email );
            return isCheckemail;
        }

        public User GetUser(int userId) 
        {
            User user=_helperlandContext.Users.Where( x => x.UserId == userId).FirstOrDefault();    
            return user;
        }
    }
}
