using ResortApi.DTOS.Payments;
using ResortApi.Models;

namespace ResortApi.Interface
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAll();
        //Task<IEnumerable<Serve>> FindAll();

        Task<object> GetById(string id);
        Task<object> GetByAccountId(string id);
        Task<object> CreatePayment(PaymentCreate data);
        Task<object> UpdatePayment(Payment data);
    }
}
