using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helperland_integration.ViewModel
{
    public class RatingViewModel
    {
        public int ServiceId { get; set; }

        public int CustId { get; set; }

        public int SPId { get; set; }

        [StringLength(2000)]
        public string Comment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime RatingDate
        {
            get
            {
                return (DateTime.Now);
            }
        }
        [Column(TypeName = "decimal(2, 1)")]
        public decimal OnTimeArrival { get; set; }
        [Column(TypeName = "decimal(2, 1)")]
        public decimal Friendly { get; set; }
        [Column(TypeName = "decimal(2, 1)")]
        public decimal QualityOfService { get; set; }

    }
}
