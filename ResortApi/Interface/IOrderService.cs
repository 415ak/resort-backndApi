using ResortApi.DTOS.Orders;
using ResortApi.Models;

namespace ResortApi.Interfaces
{
    public interface IOrderService
    {
        Task<object> GetByAccountId(string status, string accountId, int pageSize);
        Task<object> GetById(string id);
        Task<object> GetOrders(string status, int currentPage, int pageSize); 
        Task<object> CreateOrder(OrderCreate data);

        Task<object> GetForExcel();

        Task<object> ConfirmStatusPayment(string id);
        Task<object> ConfirmStatusOrder(string id);
        Task<object> CancelStatusOrder(string id);
        Task<object> SuccessStatusOrder(string id);

        Task<Order> GetByIdM(string id);
        Task DeleteImage(string fileName);
        Task UpdateOrder(Order Order);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);
    }
}
