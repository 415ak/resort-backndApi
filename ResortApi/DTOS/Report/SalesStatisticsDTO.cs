namespace ResortApi.DTOS.Report
{
    public class SalesStatisticsDTO
    {
        public double TotalPrice { get; set; }
        public List<SalesStatisticeItemDTO> Sales { get; set; } = new List<SalesStatisticeItemDTO>();
    }
    public class AccmdSalesStatisticsDTO
    {
        public double TotalPrice { get; set; }
        public List<SalesStatisticeItemDTO> Sales { get; set; } = new List<SalesStatisticeItemDTO>();
    }
    //public class ServeSalesStatisticsDTO
    //{
    //    public double TotalPrice { get; set; }
    //    public List<SalesStatisticeItemDTO> Sales { get; set; } = new List<SalesStatisticeItemDTO>();
    //}
}
    