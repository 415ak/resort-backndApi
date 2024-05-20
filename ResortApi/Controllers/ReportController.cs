using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.DTOS.FoodDrinks;
using ResortApi.DTOS.Report;
using ResortApi.Interface;
using ResortApi.interfaces;
using ResortApi.Services;
using System.Net;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService reportService;

        public ReportController(IReportService reportService)
        {
            this.reportService = reportService;
        }


        ///product
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductStatistics()
        {
            var result = await reportService.ProductStatistics();
            return Ok(new { msg = "OK", data = result });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSalesStatistics()
        {
            var result = await reportService.SalesStatistics();
            if (result == null) return Ok(new { msg = "ไม่พบสินค้า" });
            return Ok(new { msg = "OK", data = result });
        }

        ///Accmd
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAccmdStatistics()
        {
            var result = await reportService.AccmdStatistics();
            return Ok(new { msg = "OK", data = result });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAccmdSalesStatistics()
        {
            var result = await reportService.AccmdSalesStatistics();
            if (result == null) return Ok(new { msg = "ไม่พบสินค้า" });
            return Ok(new { msg = "OK", data = result });
        }

        //Serve
        [HttpGet("[action]")]
        public async Task<IActionResult> GetServeStatistics()
        {
            var result = await reportService.ServeStatistics();
            return Ok(new { msg = "OK", data = result });
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetServeSalesStatistics()
        {
            var result = await reportService.ServeSalesStatistics();
            if (result == null) return Ok(new { msg = "ไม่พบสินค้า" });
            return Ok(new { msg = "OK", data = result });
        }
    }
}
