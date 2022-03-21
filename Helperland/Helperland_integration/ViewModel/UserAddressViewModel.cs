using System.ComponentModel.DataAnnotations;

namespace Helperland_integration.ViewModel
{
    public class UserAddressViewModel
    {
        public int AddressId { get; set; }
        
        public int UserId { get; set; }

        [Required(ErrorMessage="Enter house no.")]
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
    }
}
