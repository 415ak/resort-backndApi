namespace ResortApi.DTOS.HouseBooking
{
    public class HouseBookingCreate
    {
        public string AccountId { get; set; }
        public string AccommodationId { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public string DesiredDetail { get; set; }



    }
}
