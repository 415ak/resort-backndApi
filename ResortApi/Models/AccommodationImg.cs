using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class AccommodationImg
    {
        
        public Guid AccommodationImgId { get; set; } = Guid.NewGuid();
        public string Image { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now; 
        public string AccommodationId { get; set; }

    }
}
