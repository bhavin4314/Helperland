using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helperland_integration.ViewModel
{
    public class ServiceDetailsViewModel
    {
        public int ServiceId { get; set; }
        [Column(TypeName = "date")]
        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }


        [Required(ErrorMessage = "Enter house no.")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage = "Enter street name")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Enter pincode")]
        public string ZipCode { get; set; }

       
        [Required(ErrorMessage = "Enter city name")]
        public string City { get; set; }
    }
}
