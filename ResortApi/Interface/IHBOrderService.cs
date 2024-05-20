using ResortApi.DTOS.HBOrders;
using ResortApi.Models;

namespace ResortApi.Interface
{
    public interface IHBOrderService
    {

        Task<object> GetByAccountId(string status, string accountId, int pageSize);
        Task<object> GetByAccountIdV2(string status, string accountId, int pageSize);

        Task<HBOrder> GetByIdM(string id);

        Task<object> GetById(string id);
        Task<object> GetByIdStatus(string id);
        Task<object> GetHBOrders(string status, int currentPage, int pageSize);
        Task<object> CreateHBOrder(HBOrderCreate data);

        Task DeleteImage(string fileName);
        Task UpdateHBOrder(HBOrder HBorder);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);



        Task<object> GetForExcel();

        Task<object> ConfirmStatusPayment(string id);
        Task<object> ConfirmStatusHBOrder(string id);
        Task<object> CancelStatusHBOrder(string id);
        Task<object> SuccessStatusHBOrder(string id);
    }
}
