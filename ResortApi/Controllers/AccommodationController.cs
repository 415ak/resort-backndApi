using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.DTOS.Accommodation;
using ResortApi.Interface;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        private readonly IAccommodationService accommodationService;

        public AccommodationController(IAccommodationService accommodationService)
        {
            this.accommodationService = accommodationService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var show = await accommodationService.FindAll();

            return Ok(show);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromForm] AcmdRequest data)
        {
            try
            {
                return Ok(await accommodationService.Create(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcmdById(string id)
        {
            //var ps = new ProductService(databaseContext);
            //var data = await ps.FindById(id);
            //return Ok(ProductResponse.FromProduct(data));
            try
            {
                return Ok(await accommodationService.FindById(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }




        [HttpPut("[action]/")]
        public async Task<IActionResult> Update([FromForm] AcmdUpdate data)
        {
            try
            {
                return Ok(await accommodationService.Update(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ChangeStatusDTO([FromForm] AcmdUpdateStatus data)
        {
            try
            {
                return Ok(await accommodationService.ChangeStatusDto(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            try
            {
                return Ok(await accommodationService.ChangeStatus(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }



        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteAcmd(string id)
        {
            try
            {
                object Acmd = await accommodationService.Delete(id);
                //object FdImage = await fdImgService.DeleteAll(id);
                return Ok(new { Acmd });
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }


    }
}
