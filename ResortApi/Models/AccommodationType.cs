using System.ComponentModel.DataAnnotations;

namespace ResortApi.Models
{
    public class AccommodationType
    {
        [Key]
        public string AccommodationTypeId { get; set; }
        public string Name { get; set; }
        public int IsUsed { get; set; } = 1;
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
