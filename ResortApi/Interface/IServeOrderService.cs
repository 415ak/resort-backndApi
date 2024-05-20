using ResortApi.DTOS.HBOrders;
using ResortApi.DTOS.Orders;
using ResortApi.DTOS.ServeOrders;
using ResortApi.Models;

namespace ResortApi.Interface
{
    public interface IServeOrderService
    {

        Task<object> GetByAccountId(string status, string accountId, int pageSize);
        Task<object> GetById(string id);
        //Task<object> GetServeOrders(string status, int currentPage, int pageSize);
        Task<object> GetServeOrders(
            string status,
            int currentPage, int pageSize);
        //Task<object> GetTest();
        Task<IEnumerable<ServeOrder>> GetTest();

        Task<object> CreateServeOrder(ServeOrderCreate data);

        Task<object> GetForExcel();

        Task<object> ConfirmStatusPayment(string id);
        Task<object> ConfirmStatusServeOrder(string id);
        Task<object> CancelStatusServeOrder(string id);
        Task<object> SuccessStatusServeOrder(string id);

        Task<ServeOrder> GetByIdM(string id);
        Task DeleteImage(string fileName);
        Task UpdateServeOrder(ServeOrder ServeOrder);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);
    }
}
