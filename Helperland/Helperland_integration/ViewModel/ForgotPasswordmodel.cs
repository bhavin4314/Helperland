using System.ComponentModel.DataAnnotations;

namespace Helperland_integration.ViewModel
{
    public class ForgotPasswordmodel
    {
        [Required(ErrorMessage = "Enter e-mail")]
        [EmailAddress]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
