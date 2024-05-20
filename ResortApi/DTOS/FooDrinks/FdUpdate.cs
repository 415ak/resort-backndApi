using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.FoodDrinks
{
    public class FdUpdate
    {
        [Required]
        public string FdId { get; set; }

        [Required]
        public string FdName { get; set; }

        [Required]
        public string FdDescription { get; set; }

        [Required]
        public int FdPrice { get; set; }
        //public int FdUnit { get; set; }
        //public int FdIsused { get; set; } = 1;

        [Required]

        public string FdCategoryId { get; set; }

        public IFormFileCollection? upfile { get; set; }

    }
}
