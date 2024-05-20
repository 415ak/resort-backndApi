using ResortApi.Settings;
using ResortApi.Models;

namespace ResortApi.DTOS.HBOrderItems
{
    public class HBOrderItemResponse
    {
        static public string PathServer = "https://localhost:5000/images/";
        static public object HBOrderItemsProduct(HBOrderItem data) => new
        {
            AcmdName = data.Accommodation.Name,
            AcmdPrice = data.Accommodation.Price,
            //data.CheckIn,
            //data.CheckOut,
            //SumPrice = data.Amount * data.FoodDrink.FdPrice
            //SumPrice = CalculatePrice(data.Accommodation.Price, data.CheckIn, data.CheckOut),

        };

        private static float CalculatePrice(int price, DateTime checkIn, DateTime checkOut)
        {
            TimeSpan date = checkOut - checkIn;
            var sum = date.Days * price;

            return sum;
        }

        static public object HBOrderItemsProductOneImg(HBOrderItem data) => new
        {
            data.Id,
            data.CheckIn,
            data.CheckOut,
            //SumPrice = CalculatePrice(data.Accommodation.Price, data.CheckIn, data.CheckOut),
            data.AccommodationId,
            AcmdName = data.Accommodation.Name,
            AcmdPrice = data.Accommodation.Price,
            Image = data.Accommodation.AccommodationImgs.Count > 0
                ? Constants.PathServer + data.Accommodation.AccommodationImgs.First().Image
                : null,
        };

        static public object HBOrderItemsProductCateOneImg(HBOrderItem data) => new
        {
            data.Id,
            data.CheckIn,
            data.CheckOut,
            //SumPrice = CalculatePrice(data.Accommodation.Price, data.CheckIn, data.CheckOut),
            data.AccommodationId,
            AcmdType = data.Accommodation.AccommodationType.Name,
            AcmdName = data.Accommodation.Name,
            AcmdPrice = data.Accommodation.Price,
            Image = data.Accommodation.AccommodationImgs.Count > 0
                ? Constants.PathServer + data.Accommodation.AccommodationImgs.First().Image
                : null,
        };
    }
}
