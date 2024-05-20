using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.Accommodation
{
    public class AcmdUpdate
    {
        [Required]
        public string AccommodationId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public string AccommodationTypeId { get; set; }
    }

    
}
