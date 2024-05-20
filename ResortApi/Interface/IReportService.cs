using ResortApi.DTOS.Report;

namespace ResortApi.interfaces
{
    public interface IReportService
    {
        Task<List<AccmdStatisticsDTO>> AccmdStatistics();
        Task<List<ServeStatisticsDTO>> ServeStatistics();
        Task<List<ProductStatisticsDTO>> ProductStatistics();

        Task<SalesStatisticsDTO> SalesStatistics();
        Task<SalesStatisticsDTO> AccmdSalesStatistics();
        Task<SalesStatisticsDTO> ServeSalesStatistics();


    }
}
