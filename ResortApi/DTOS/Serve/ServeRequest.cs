using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.Serve
{
    public class ServeRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Detail { get; set; }

        //public IFormFileCollection? ServeImage { get; set; }


        //[Required]
        //public string ServeTypeId { get; set; }


        
    }
}
