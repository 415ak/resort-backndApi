using ResortApi.Settings;
using ResortApi.Models;

namespace ResortApi.DTOS.Payments
{
    public class PaymentResponse
    {
        static public object Payment(Payment data) => new
        {
            data.Id,
            ImgPay = Constants.PathServer + data.ImgPay,
            data.AccountId,
            data.Status,
            data.Detail,
            data.Createdate
        };
    }
}
