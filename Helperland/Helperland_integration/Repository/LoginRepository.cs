using Helperland_integration.Data;
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

        public bool IsValidUser(LoginViewModel loginViewModel)
        {
            bool isCheckUser = _helperlandContext.Users.Any(x => x.Email == loginViewModel.Email && x.Password == loginViewModel.Password);
            return isCheckUser;
        }
    }
}
