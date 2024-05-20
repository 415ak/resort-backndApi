using ResortApi.Models.OrderAggregate;

namespace ResortApi.DTOS.HBOrders
{
    public class HBOrderPaymentRequest
    {
        public string? Id { get; set; }
        public IFormFileCollection? FormFiles { get; set; }

        public PaymentStatus Status { get; set; }
        //Id { get; set; }

    }

}