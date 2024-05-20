namespace ResortApi.DTOS.ServeOrders
{
    public class ServeOrderPaymentRequest
    {
        public string? Id { get; set; }
        public IFormFileCollection? FormFiles { get; set; }
    }

}