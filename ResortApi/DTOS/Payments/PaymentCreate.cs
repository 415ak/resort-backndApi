using System.ComponentModel.DataAnnotations;

namespace ResortApi.DTOS.Payments
{
    public class PaymentCreate
    {

        public string? OrderId { get; set; }
        public string? HBOrderId { get; set; }
        public string? ServeOrderId { get; set; }
        //[Required]
        public string AccountId { get; set; }
        public string Detail { get; set; }

        public IFormFileCollection? ImgPay { get; set; }
    }
}
