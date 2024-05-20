using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string FdId { get; set; }
        public int Amount { get; set; }
        public DateTime CreateDate { get; set; }


        [ForeignKey("FdId")]
        [ValidateNever]
        public FoodDrink FoodDrink { get; set; }
    }
}