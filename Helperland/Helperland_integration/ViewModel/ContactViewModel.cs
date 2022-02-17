
using System.ComponentModel.DataAnnotations;

namespace Helperland_integration.ViewModel
{
    public class ContactViewModel
    {
        //public int ContactUsId { get; set; }

        [Required(ErrorMessage = "Enter FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter e-mail")]
        [EmailAddress(ErrorMessage = "please enter valid email")]
        public string Email { get; set; }

        public string Subject { get; set; }

        [Required(ErrorMessage = "Enter mobile number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter message")]
        public string Message { get; set; }
        //public string UploadFileName { get; set; }
   
    }
}
