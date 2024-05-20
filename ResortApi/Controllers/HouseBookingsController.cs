using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.Interface;
using ResortApi.Settings;
using ResortApi.DTOS.HouseBooking;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HouseBookingsController : ControllerBase
    {
        private readonly IHouseBookingService houseBookingService;

        public HouseBookingsController(IHouseBookingService houseBookingService)
        {
            this.houseBookingService = houseBookingService;
        }


        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetAllHouseBooking(string? status = "", int currentPage = 1, int pageSize = 10)
        //{
        //    try
        //    {
        //        return Ok(await houseBookingService.GetAllHouseBooking(status, currentPage, pageSize));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(Constants.Return400(e.Message));
        //    }
        //}

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByAccountId(string id)
        {
            try
            {
                return Ok(await houseBookingService.GetBookHouseByAccountId(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateHouseBooking([FromForm] HouseBookingCreate data)
        {
            try
            {
                return Ok(await houseBookingService.CreateHouseBooking(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteHouseBooking(int id)
        {
            try
            {
                return Ok(await houseBookingService.DeleteHouseBooking(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }


    }
}
