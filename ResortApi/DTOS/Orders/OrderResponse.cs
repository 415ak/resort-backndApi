//using ResortApi.DTOS.Accounts;
//using ResortApi.DTOS.Addresses;
using ResortApi.DTOS.OrderItems;
//using ResortApi.DTOS.Payments;
using ResortApi.Settings;
using ResortApi.Models;

namespace ResortApi.DTOS.Orders
{
    public class OrderResponse
    {
        static public object OrdersProductOneImg(Order data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            data.Total,
            data.CreateDate,
        //public string AccommodationId { get; set; }

        //data.TransportationCode,
            ItemCount = data.OrderItem.Count,
            //AccountId = data.OrderItem.First().Account.AccountId,
            //AccountName = data.OrderItem.First().Account.FirstName + data.OrderItem.First().Account.LastName,
            ProductId = data.OrderItem.First().FoodDrink.FdId,
            ProductName = data.OrderItem.First().FoodDrink.FdName,
            ProductItemAmount = data.OrderItem.First().Amount,
            ProductPrice = data.OrderItem.First().FoodDrink.FdPrice,
            ProductAmountPrice = data.OrderItem.First().Amount * data.OrderItem.First().FoodDrink.FdPrice,
            ProductImage = data.OrderItem.Count > 0
                ? data.OrderItem.First().FoodDrink.FdImgs.Count > 0
                    ? Constants.PathServer + data.OrderItem.First().FoodDrink.FdImgs.First().FdImgName
                    : null
                : null,
        };

        static public object OrdersProductOneImgOneTran(Order data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            data.Total,
            data.CreateDate,
            //data.TransportationCode,
            ItemCount = data.OrderItem.Count,
            transport = data.AccommodationId,
            //AccountId = data.OrderItem.First().Account.AccountId,
            //AccountName = data.OrderItem.First().Account.FirstName + data.OrderItem.First().Account.LastName,
            ProductId = data.OrderItem.First().FoodDrink.FdId,
            ProductName = data.OrderItem.First().FoodDrink.FdName,
            ProductItemAmount = data.OrderItem.First().Amount,
            ProductPrice = data.OrderItem.First().FoodDrink.FdPrice,
            ProductAmountPrice = data.OrderItem.First().Amount * data.OrderItem.First().FoodDrink.FdPrice,
            ProductImage = data.OrderItem.Count > 0
                ? data.OrderItem.First().FoodDrink.FdImgs.Count > 0
                    ? Constants.PathServer + data.OrderItem.First().FoodDrink.FdImgs.First().FdImgName
                    : null
                : null,
            //Transportation = data.Transportation.Count > 0
            //    ? TransportationFormatLastData(data.Transportation)
            //    : null,
        };

        static public object OrderItemsAddressPaymentProductOneImg(Order data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            data.Total,
            data.CreateDate,
            //data.TransportationCode,
            //Address = AddressResponse.AddressRes(data.Address),
            //Payment = data.Payment.Count > 0
            //    ? data.Payment.Select(PaymentResponse.Payment)
            //    : null,
            OrderItem = data.OrderItem.Count > 0
                ? data.OrderItem.Select(OrderItemResponse.OrderItemsProductOneImg)
                : null,
        };

        static public object OrderItemsAddressPaymentProduct(Order data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            data.Total,
            data.CreateDate,
            //data.TransportationCode,
            //AccountId = data.Address.AccountId,
            //Address = AddressResponse.AddressRes(data.Address),
            //Payment = data.Payment.Count > 0
            //    ? data.Payment.Select(PaymentResponse.Payment)
            //    : null,
            OrderItem = data.OrderItem.Count > 0
                ? data.OrderItem.Select(OrderItemResponse.OrderItemsProduct)
                : null,
        };

        static public object OrderItemsAccountAddressPaymentProductOneImg(Order data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            data.Total,
            data.CreateDate,
            //data.TransportationCode,
            //Account = AccountResponse.Account(data.Address.Account),
            //Address = AddressResponse.AddressRes(data.Address),
            //Payment = data.Payment.Count > 0
            //    ? data.Payment.Select(PaymentResponse.Payment)
            //    : null,
            OrderItem = data.OrderItem.Count > 0
                ? data.OrderItem.Select(OrderItemResponse.OrderItemsProductOneImg)
                : null,
        };

        static public object OrderItemsAccountAddressPaymentProductCateOneImg(Order data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            data.Total,
            data.CreateDate,
            //data.TransportationCode,
            //Account = AccountResponse.Account(data.Address.Account),
            //Address = AddressResponse.AddressRes(data.Address),
            //Payment = data.Payment.Count > 0
            //    ? data.Payment.Select(PaymentResponse.Payment)
            //    : null,
            OrderItem = data.OrderItem.Count > 0
                ? data.OrderItem.Select(OrderItemResponse.OrderItemsProductCateOneImg)
                : null,
        };

        static public object OrderItemsAccountAddressPaymentProductCateOneImgTran(Order data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            data.Total,
            data.CreateDate,
            //data.TransportationCode,
            //Account = AccountResponse.Account(data.Address.Account),
            //Address = AddressResponse.AddressRes(data.Address),
            //Payment = data.Payment.Count > 0
            //    ? data.Payment.Select(PaymentResponse.Payment)
            //    : null,
            OrderItem = data.OrderItem.Count > 0
                ? data.OrderItem.Select(OrderItemResponse.OrderItemsProductCateOneImg)
                : null,
            //Transportation = data.Transportation.Count > 0
            //    ? TransportationFormat(data.Transportation).Select(a => new { a.Id, a.Status, a.Detail, date = a.CreateDate })
            //    : null,
        };

        //static private object TransportationFormatLastData(ICollection<Transportation> data)
        //{
        //    var result = data.OrderByDescending(a => a.CreateDate).First();
        //    return new { result.Status, result.Detail, date = result.CreateDate };
        //}

        //static private List<Transportation> TransportationFormat(ICollection<Transportation> data) => data.OrderBy(a => a.CreateDate).ToList();


    }
}
