using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class FoodDrink
    {
        //public FoodDrink()
        //{
        //    FdImg = new HashSet<FdImg>();
        //}
        [Key]
        public string FdId { get; set; }
        public string FdName { get; set; }
        public string FdDescription { get; set; }
        public int FdPrice { get; set; }
        //public string? Image { get; set; }
        //public int FdUnit { get; set; }
        public int FdIsused { get; set; } = 1;
        public DateTime DateTime { get; set; } = DateTime.Now;

        public string FdCategoryId { get; set; }
        [ForeignKey("FdCategoryId")] 
        public FdCategory FdCategory { get; set; }
       
        public  ICollection<FdImg> FdImgs { get; set; } = new List<FdImg>();


    }
}
