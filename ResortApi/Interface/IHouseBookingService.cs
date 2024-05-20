using ResortApi.DTOS.HouseBooking;

namespace ResortApi.Interface
{
    public interface IHouseBookingService
    {
        Task<object> GetBookHouseByAccountId(string id);
        //Task<object> ItemPlus(int id);
        //Task<object> ItemRemove(int id);
        Task<object> CreateHouseBooking(HouseBookingCreate data);
        //Task<object> CancelHouseBooking(int id);
        Task<object> GetAllHouseBooking(string status, int currentPage, int pageSize);

        Task<object> DeleteHouseBooking(int id);
        Task<object> DeleteHouseBookingToOrder(int id);

    }
}
