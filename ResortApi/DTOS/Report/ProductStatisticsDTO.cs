using ResortApi.Models;

namespace ResortApi.DTOS.Report
{
    public class ProductStatisticsDTO
    {
        public FoodDrink Product { get; set; }
        public double? NumPercen { get; set; }
        public double? Amount { get; set; }
    }

    public class AccmdStatisticsDTO
    {
        public Models.Accommodation Accmd { get; set; }
        public double? NumPercen { get; set; }
        public double? Amount { get; set; }
    }

    public class ServeStatisticsDTO
    {
        public Models.Serve Serve { get; set; }
        public double? NumPercen { get; set; }
        public double? Amount { get; set; }
    }
}
