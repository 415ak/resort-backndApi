using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.DTOS.Accommodation;
using ResortApi.Interface;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccommodationTypeController : ControllerBase
    {
        private readonly IAccommodationTypeService acmdTypeService;
        private readonly DatabaseContext context;

        public AccommodationTypeController(IAccommodationTypeService acmdTypeService, DatabaseContext context)
        {
            this.acmdTypeService = acmdTypeService;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await acmdTypeService.GetAll();
            return Ok(result);
        }



        [HttpPost("[action]")] //[FromBody]-Json [FromForm]-Multipart/form-data
        public async Task<IActionResult> Create([FromForm] AcmdTypeRequest data/*,string fdImgId*/ )
        {
            //var FdImg = await context.FdImgs.Include(x => x.FoodDrink).FirstOrDefaultAsync(x => x.FdImgId.Equals(fdImgId));
            //if (FdImg == null) BadRequest();
            try
            {
                return Ok(await acmdTypeService.Create(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }
    }
}
