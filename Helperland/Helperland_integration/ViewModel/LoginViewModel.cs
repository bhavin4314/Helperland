//using System;
using System.ComponentModel.DataAnnotations;

namespace Helperland_integration.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
