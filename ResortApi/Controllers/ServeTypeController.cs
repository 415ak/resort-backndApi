using Microsoft.AspNetCore.Mvc;
using ResortApi.DTOS.Serve;
using ResortApi.Interface;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServeTypeController : ControllerBase
    {
        private readonly IServeTypeService serveTypeService;

        //private readonly IAccommodationTypeService acmdTypeService;
        //private readonly DatabaseContext context;

        public ServeTypeController(IServeTypeService serveTypeService)
        {
            this.serveTypeService = serveTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await serveTypeService.GetAll();
            return Ok(result);
        }



        [HttpPost("[action]")] //[FromBody]-Json [FromForm]-Multipart/form-data
        public async Task<IActionResult> Create([FromForm] ServeTypeRequest data/*,string fdImgId*/ )
        {
            //var FdImg = await context.FdImgs.Include(x => x.FoodDrink).FirstOrDefaultAsync(x => x.FdImgId.Equals(fdImgId));
            //if (FdImg == null) BadRequest();
            try
            {
                return Ok(await serveTypeService.Create(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }


    }
}
