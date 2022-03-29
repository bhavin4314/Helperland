using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helperland_integration.ViewModel
{
    public class spDetailsViewModel
    {
        [Required(ErrorMessage = "Enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Enter e-mail")]
        [EmailAddress(ErrorMessage = "please enter valid email")]
        public string Email { get; set; }

        public int AddressId { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter house no.")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "Enter street name")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Enter pincode")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Enter mobile no.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Not a valid phone number")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Enter city name")]
        public string City { get; set; }

        public string Avatar { get; set; }

        public int? NationalityId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
    }
}
