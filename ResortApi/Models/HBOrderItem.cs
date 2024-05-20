using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class HBOrderItem
    {
        [Key]
        public string Id { get; set; }

        //public int Amount { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string DesiredDetail { get; set; }
        public string HBOrderId { get; set; }

        //[ForeignKey("HBOrderId")]
        //[ValidateNever]
        //public HBOrder HBOrder { get; set; }


        public string AccommodationId { get; set; }

        [ForeignKey("AccommodationId")]
        [ValidateNever]
        public Accommodation Accommodation { get; set; }
    }
}
