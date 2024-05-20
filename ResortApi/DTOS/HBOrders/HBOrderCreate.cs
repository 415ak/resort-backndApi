using ResortApi.DTOS.HBOrderItems;
using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.HBOrders
{
    public class HBOrderCreate
    {
        //[Required]
        //public int AddressId { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public string AccountId { get; set; }

        [Required]
        public List<HBOrderItemCreate> HBOrderItem { get; set; } 
    }
}
