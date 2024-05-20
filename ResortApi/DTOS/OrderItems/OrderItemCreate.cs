using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.OrderItems
{
    public class OrderItemCreate
    {
        [Required]
        public int IdCartItem { get; set; } 
        [Required]
        public string FdId { get; set; }

        //[Required]
        //public string AccountId { get; set; }

        [Required]
        public int Amount { get; set; } 
    }
}
