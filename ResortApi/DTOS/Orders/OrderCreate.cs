using ResortApi.DTOS.OrderItems;
using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.Orders
{
    public class OrderCreate
    {
        [Required]
        public string AccommodationId { get; set; }

        [Required]
        public string AccountId { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public List<OrderItemCreate> OrderItem { get; set; } 
    }
}
