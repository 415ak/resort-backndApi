namespace ResortApi.DTOS.CartItems
{
    public class CartItemCreate
    {  
        public string AccountId { get; set; }
        public string FdId { get; set; }
        public int Amount { get; set; }  
    }
}
