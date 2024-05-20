using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class FdImg
    {
        
        public Guid FdImgId { get; set; } = Guid.NewGuid();
        public string FdImgName { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now; 
        public string FoodDrinkFdId { get; set; }

        //public ICollection<FoodDrink> FoodDrink { get; set; } = new List<FoodDrink>();

        //[Key]
        //public string FdImgId { get; set; }
        //public string FdImgName { get; set; }
        //public DateTime? CreateDate { get; set; }
        //public string FdId { get; set; }
        //[ForeignKey("FdId")]
        //public virtual FoodDrink FoodDrink { get; set; }

    }
}
