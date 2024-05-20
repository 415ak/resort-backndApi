using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class Serve
    {
        [Key]
        public int ServeId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int IsUsed { get; set; } = 1;
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        //public string? ServeImage { get; set; }

        //public string ServeTypeId { get; set; }
        //[ValidateNever]
        //[ForeignKey("ServeTypeId")]
        //public virtual ServeType ServeType { get; set; }


        public ICollection<ServeImg> ServeImgs { get; set; } = new List<ServeImg>();
    }
}
