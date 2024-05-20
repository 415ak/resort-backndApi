using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class HouseBooking
    {
        [Key]
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string AccommodationId { get; set; }
        //public int Price { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string DesiredDetail { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int IsUsed { get; set; }


        [ForeignKey("AccommodationId")]
        [ValidateNever]
        public Accommodation Accommodation { get; set; }
    }
}
