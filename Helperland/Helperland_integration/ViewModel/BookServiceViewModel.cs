using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helperland_integration.ViewModel
{
    public class BookServiceViewModel
    {

        [Column(TypeName = "date")]
        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public double ServiceHours { get; set; }

        public double ExtraHours { get; set; }

        public string Comments { get; set; }

        public bool HasPets { get; set; }
        public int? Status { get; set; }

        public bool ExtraService1 { get; set; }

        public bool ExtraService2 { get; set; }

        public bool ExtraService3 { get; set; }

        public bool ExtraService4 { get; set; }

        public bool ExtraService5 { get; set; }

        [Required]
        public string Zipcode { get; set; }

        public int AddressId { get; set; }

        public int userId { get; set; }

        public int serviceId { get; set; }
    }
}
