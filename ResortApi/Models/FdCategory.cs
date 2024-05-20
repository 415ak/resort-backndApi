using System.ComponentModel.DataAnnotations;

namespace ResortApi.Models
{
    public class FdCategory
    {
        [Key]
        public string FdCategoryId { get; set; }
        public string Name { get; set; }
        public int IsUsed { get; set; } = 1;
        public DateTime DateTime { get; set; }
    }
}
 