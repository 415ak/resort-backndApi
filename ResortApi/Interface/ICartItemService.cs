using ResortApi.DTOS.CartItems;

namespace ResortApi.Interface
{
    public interface ICartItemService
    {
        Task<object> GetCartItemByAccountId(string id);
        Task<object> ItemPlus(CartItemPR data);
        Task<object> ItemRemove(CartItemPR data);
        //Task<object> ItenEdit()
        Task<object> CreateCartItem(CartItemCreate data);
        Task<object> DeleteCartItem(int id);

    }
}
