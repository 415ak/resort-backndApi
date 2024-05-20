using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.ServeOrderItems
{
    public class ServeOrderItemCreate
    {
        [Required]
        public int IdServeCart { get; set; } 

        [Required]
        public int ServeId { get; set; }

        //[Required]
        //public string AccountId { get; set; }

        [Required]
        public int Amount { get; set; } 
    }
}
