using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResortApi.Models
{
    public class OrderItem
    {
        [Key]
        public string Id { get; set; }
        public string FdId { get; set; }
        public int Amount { get; set; }

        //public string AccountId { get; set; }
        public string OrderId { get; set; }

        //[ForeignKey("OrderId")]
        //[ValidateNever]
        //public Order Order { get; set; }

        //[ForeignKey("AccountId")]
        //[ValidateNever]
        //public Account Account { get; set; }

        [ForeignKey("FdId")]
        [ValidateNever]
        public FoodDrink FoodDrink { get; set; }
    }
}
