using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.HBOrderItems
{
    public class HBOrderItemCreate
    {
        [Required]
        public int IdHBooking { get; set; }

        [Required]
        public string AccommodationId { get; set; }

        //[Required]
        //public string AccountId { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        public string DesiredDetail { get; set; }
    }
}
