using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.FoodDrinks
{
    public class FdCategoryRequest
    {
        [Required]
        public string Name { get; set; }

        //[Required]
        //public int IsUsed { get; set; } = 1;
    }
}
