using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.Serve
{
    public class ServeTypeRequest
    {
        [Required]
        public string Name { get; set; }
    }

}
