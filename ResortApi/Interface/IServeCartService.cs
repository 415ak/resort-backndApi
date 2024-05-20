using ResortApi.DTOS.ServeCart;

namespace ResortApi.Interface
{
    public interface IServeCartService
    {
        Task<object> GetCartItemByAccountId(string id);
        //Task<object> ItemPlus(int id);
        //Task<object> ItemRemove(int id);
        //Task<object> ItenEdit()
        Task<object> Update(ServeCartUpdate data);
        Task<object> CreateServeCart(ServeCartCreate data);
        Task<object> DeleteServeCart(int id);
        //Task Update(object result);
    }
}
