namespace ResortApi.DTOS.Orders
{
    public class OrderPaymentRequest
    {
        public string? Id { get; set; }
        public IFormFileCollection? FormFiles { get; set; }
    }

}