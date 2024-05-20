using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.ServeCart
{
    public class ServeCartUpdate
    {
        [Required]
        public int Id { get; set; }
        //[Required]
        //public string AccountId { get; set; }
        //[Required]
        //public int ServeId { get; set; }
        [Required]
        public int Amount { get; set; }

    }
}
