using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.Accommodation
{
    public class AcmdTypeRequest
    {
        [Required]
        public string Name { get; set; }

        //[Required]
        //public int IsUsed { get; set; } = 1;
    }
}
