using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Helperland_integration.ViewModel
{
    public class AddressViewModel
    {
        public int AddressId { get; set; }
        [JsonPropertyName("userId")]
        public int? UserId { get; set; }
        [JsonPropertyName("addressLine1")]
        public string AddressLine1 { get; set; }
        [JsonPropertyName("addressLine2")]
        public string AddressLine2 { get; set; }
        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }
        [JsonPropertyName("mobileNo")]
        public string MobileNo { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
    }
}
