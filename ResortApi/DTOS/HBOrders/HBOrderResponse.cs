//using ResortApi.DTOS.Accounts;
//using ResortApi.DTOS.Addresses;
using ResortApi.DTOS.OrderItems;
//using ResortApi.DTOS.Payments;
using ResortApi.Settings;
using ResortApi.Models;
using ResortApi.DTOS.HBOrderItems;

namespace ResortApi.DTOS.HBOrders
{
    public class HBOrderResponse
    {
        static public object HBOrdersProductOneImg(HBOrder data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,

            data.Total,
            data.CreateDate,
            //data.TransportationCode,
            
            ItemCount = data.HBOrderItem.Count,
            HBId = data.HBOrderItem.First().Accommodation.AccommodationId,
            HBName = data.HBOrderItem.First().Accommodation.Name,
            //HBAmountDate = data.OrderItem.First().Amount,
            HBAmountDate = DateBooking(data.HBOrderItem.First().CheckIn, data.HBOrderItem.First().CheckOut),
            HBcheckIn = data.HBOrderItem.First().CheckIn,
            HBcheckOut = data.HBOrderItem.First().CheckOut,
            HBPrice = data.HBOrderItem.First().Accommodation.Price,
            //ProductAmountPrice = data.HBOrderItem.First().Amount * data.OrderItem.First().FoodDrink.FdPrice,
            SumDate = DateBooking(data.HBOrderItem.First().CheckIn, data.HBOrderItem.First().CheckOut),
            SumPrice = CalculatePrice(data.HBOrderItem.First().Accommodation.Price, data.HBOrderItem.First().CheckIn, data.HBOrderItem.First().CheckOut),
            ProductImage = data.HBOrderItem.Count > 0
                ? data.HBOrderItem.First().Accommodation.AccommodationImgs.Count > 0
                    ? Constants.PathServer + data.HBOrderItem.First().Accommodation.AccommodationImgs.First().Image
                    : null
                : null,
        };

        private static float DateBooking(DateTime checkIn, DateTime checkOut)
        {
            TimeSpan date = checkOut - checkIn;
            var sumdate = date.Days;

            return sumdate;
        }

        private static float CalculatePrice(int price, DateTime checkIn, DateTime checkOut)
        {
            TimeSpan date = checkOut - checkIn;
            var sum = date.Days * price;

            return sum;
        }

        static public object HBOrdersProductOneImgOneTran(HBOrder data) => new
        {
            data.Id,
            data.Status,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            data.Total,
            data.CreateDate,

            //data.TransportationCode,
            ItemCount = data.HBOrderItem.Count,
            AccountId = data.AccountId,
            //Account = data.OrderItem.First().Account.AccountId,
            AcmdId = data.HBOrderItem.First().Accommodation.AccommodationId,
            Name = data.HBOrderItem.First().Accommodation.Name,
            Price = data.HBOrderItem.First().Accommodation.Price,
            HbcheckIn = data.HBOrderItem.First().CheckIn,
            HbcheckOut = data.HBOrderItem.First().CheckOut,
            SumDate = DateBooking(data.HBOrderItem.First().CheckIn, data.HBOrderItem.First().CheckOut),
            SumPrice = CalculatePrice(data.HBOrderItem.First().Accommodation.Price, data.HBOrderItem.First().CheckIn, data.HBOrderItem.First().CheckOut),
            Image = data.HBOrderItem.Count > 0
                ? data.HBOrderItem.First().Accommodation.AccommodationImgs.Count > 0
                    ? Constants.PathServer + data.HBOrderItem.First().Accommodation.AccommodationImgs.First().Image
                    : null
                : null,
            //Transportation = data.Transportation.Count > 0
            //    ? TransportationFormatLastData(data.Transportation)
            //    : null,
        };

        static public object OrderItemsAddressPaymentProductOneImg(HBOrder data) => new
        {
            data.Id,
            data.Status,
            data.Total,
            data.CreateDate,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,
            //data.TransportationCode,
            //Address = AddressResponse.AddressRes(data.Address),
            //Payment = data.Payment.Count > 0
            //    ? data.Payment.Select(PaymentResponse.Payment)
            //    : null,
            HBOrderItem = data.HBOrderItem.Count > 0
                ? data.HBOrderItem.Select(HBOrderItemResponse.HBOrderItemsProductOneImg)
                : null,
        };

        static public object OrderItemsAddressPaymentProduct(HBOrder data) => new
        {
            data.Id,
            data.Status,
            data.Total,
            data.CreateDate,
            Payimage = data.ImagePay != null
            ? Constants.PathServer + data.ImagePay
            : null,


            //data.TransportationCode,
            //AccountId = data.Address.AccountId,
            //Address = AddressResponse.AddressRes(data.Address),
            //Payment = data.Payment.Count > 0
            //    ? data.Payment.Select(PaymentResponse.Payment)
            //    : null,
            HBOrderItem = data.HBOrderItem.Count > 0
                ? data.HBOrderItem.Select(HBOrderItemResponse.HBOrderItemsProduct)
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

        static public object OrderItemsAccountAddressPaymentProductCateOneImgTran(HBOrder data) => new
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
            HBOrderItem = data.HBOrderItem.Count > 0
                ? data.HBOrderItem.Select(HBOrderItemResponse.HBOrderItemsProductCateOneImg)
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
