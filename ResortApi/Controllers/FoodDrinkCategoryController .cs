using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.DTOS.Accommodation;
using ResortApi.DTOS.FoodDrinks;
using ResortApi.Interface;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FoodDrinkCategoryController : ControllerBase
    {
        private readonly IFdCategoryService fdCategoryService;
        private readonly DatabaseContext context;

        public FoodDrinkCategoryController(IFdCategoryService fdCategoryService, DatabaseContext context)
        {
            this.fdCategoryService = fdCategoryService;
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await fdCategoryService.GetAll();
            return Ok(result);
        }



        [HttpPost("[action]")] //[FromBody]-Json [FromForm]-Multipart/form-data
        public async Task<IActionResult> Create([FromForm] FdCategoryRequest data/*,string fdImgId*/ )
        {
            //var FdImg = await context.FdImgs.Include(x => x.FoodDrink).FirstOrDefaultAsync(x => x.FdImgId.Equals(fdImgId));
            //if (FdImg == null) BadRequest();
            try
            {
                return Ok(await fdCategoryService.Create(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpDelete("[action]/{id}")] //[FromBody]-Json [FromForm]-Multipart/form-data
        public async Task<IActionResult> Delete(string id/*,string fdImgId*/ )
        {
            //var FdImg = await context.FdImgs.Include(x => x.FoodDrink).FirstOrDefaultAsync(x => x.FdImgId.Equals(fdImgId));
            //if (FdImg == null) BadRequest();
            try
            {
                return Ok(await fdCategoryService.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }
    }
}
