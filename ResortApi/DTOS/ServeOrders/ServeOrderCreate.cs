using ResortApi.DTOS.OrderItems;
using ResortApi.DTOS.ServeOrderItems;
using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.ServeOrders
{
    public class ServeOrderCreate
    {
        [Required]
        public int Total { get; set; }

        [Required]
        public string AccountId { get; set; }

        [Required]
        public List<ServeOrderItemCreate> ServeOrderItem { get; set; } 
    }
}
