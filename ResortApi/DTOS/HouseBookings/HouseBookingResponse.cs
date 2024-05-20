using ResortApi.Settings;
using ResortApi.Models;


namespace ResortApi.DTOS.HouseBooking
{
    public class HouseBookingResponse
    {

        static public object BookingHouseCateOneImg(ResortApi.Models.HouseBooking data) => new
            {
                data.Id,
                data.AccommodationId,
                data.CheckIn,
                data.CheckOut,
                data.DesiredDetail,
                //data.Price,
                //data.Amount,
                data.CreateDate,
                SumPrice = CalculatePrice(data.Accommodation.Price,data.CheckIn, data.CheckOut),
                    Name = data.Accommodation.Name,
                    AccommodationTypes = data.Accommodation.AccommodationType.Name,
                    Price = data.Accommodation.Price,
                    Image = data.Accommodation.AccommodationImgs.Count > 0
                        ? Constants.PathServer + data.Accommodation.AccommodationImgs.First().Image
                        : null,
            };

        private static float CalculatePrice(int price,DateTime checkIn,DateTime checkOut)
        {
            TimeSpan date = checkOut - checkIn;
            var sum = date.Days * price;
            
            return sum; 
        }


        
    }
}
