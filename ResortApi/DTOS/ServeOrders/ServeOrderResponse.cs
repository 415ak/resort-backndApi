//using ResortApi.DTOS.Payments;
using ResortApi.Settings;
using ResortApi.Models;
using ResortApi.DTOS.ServeOrderItems;

namespace ResortApi.DTOS.Orders
{
    public class ServeOrderResponse
    {
        static public object OrdersProductOneImg(ServeOrder data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            data.Total,
            data.CreateDate,
            //data.TransportationCode,
            ItemCount = data.ServeOrderItem.Count,
            //AccountId = data.OrderItem.First().Account.AccountId,
            //AccountName = data.OrderItem.First().Account.FirstName + data.OrderItem.First().Account.LastName,
            ServeId = data.ServeOrderItem.First().Serve.ServeId,
            Name = data.ServeOrderItem.First().Serve.Name,
            Amount = data.ServeOrderItem.First().Amount,
            Price = data.ServeOrderItem.First().Serve.Price,
            SumPrice = data.ServeOrderItem.First().Amount * data.ServeOrderItem.First().Serve.Price,
            Image = data.ServeOrderItem.Count > 0
                ? data.ServeOrderItem.First().Serve.ServeImgs.Count > 0
                    ? Constants.PathServer + data.ServeOrderItem.First().Serve.ServeImgs.First().Image
                    : null
                : null,
        };


        static public object OrdersProductOneImgOneTran(ServeOrder data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            data.Total,
            data.CreateDate,
            //data.TransportationCode,
            ItemCount = data.ServeOrderItem.Count,
            //AccountId = data.OrderItem.First().Account.AccountId,
            //AccountName = data.OrderItem.First().Account.FirstName + data.OrderItem.First().Account.LastName,
            ServeId = data.ServeOrderItem.First().Serve.ServeId,
            Name = data.ServeOrderItem.First().Serve.Name,
            Amount = data.ServeOrderItem.First().Amount,
            Price = data.ServeOrderItem.First().Serve.Price,
            SumPrice = data.ServeOrderItem.First().Amount * data.ServeOrderItem.First().Serve.Price,
            Image = data.ServeOrderItem.Count > 0
                ? data.ServeOrderItem.First().Serve.ServeImgs.Count > 0
                    ? Constants.PathServer + data.ServeOrderItem.First().Serve.ServeImgs.First().Image
                    : null
                : null,
            //Transportation = data.Transportation.Count > 0
            //    ? TransportationFormatLastData(data.Transportation)
            //    : null,
        };

        static public object OrderItemsAddressPaymentProductOneImg(ServeOrder data) => new
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
            OrderItem = data.ServeOrderItem.Count > 0
                ? data.ServeOrderItem.Select(ServeOrderItemResponse.OrderItemsProductOneImg)
                : null,
        };

        static public object OrderItemsAddressPaymentProduct(ServeOrder data) => new
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
            OrderItem = data.ServeOrderItem.Count > 0
                ? data.ServeOrderItem.Select(ServeOrderItemResponse.OrderItemsProduct)
                : null,
        };

        static public object OrderItemsAccountAddressPaymentProductOneImg(ServeOrder data) => new
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
            OrderItem = data.ServeOrderItem.Count > 0
                ? data.ServeOrderItem.Select(ServeOrderItemResponse.OrderItemsProductOneImg)
                : null,
        };

        static public object OrderItemsAccountAddressPaymentProductCateOneImg(ServeOrder data) => new
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
            OrderItem = data.ServeOrderItem.Count > 0
                ? data.ServeOrderItem.Select(ServeOrderItemResponse.OrderItemsProductCateOneImg)
                : null,
        };

        static public object OrderItemsAccountAddressPaymentProductCateOneImgTran(ServeOrder data) => new
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
            OrderItem = data.ServeOrderItem.Count > 0
                ? data.ServeOrderItem.Select(ServeOrderItemResponse.OrderItemsProductCateOneImg)
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
