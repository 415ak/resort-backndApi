using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.FdImg;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FoodDrinkImageController : ControllerBase
    {
        private readonly DatabaseContext context;
        private readonly IFdImgService fdImgService;
        private readonly IUploadFileService uploadFileService;

        public FoodDrinkImageController( DatabaseContext context,IUploadFileService uploadFileService,IFdImgService fdImgService)
        {
            this.context = context;
            this.uploadFileService = uploadFileService;
            this.fdImgService = fdImgService;
        }

        [HttpPost("[action]")]
        //public async Task<ActionResult<FdImg>> Create([FromForm] IFormFileCollection formFiles,string prodeuctId)
        public async Task<ActionResult<FdImg>> Create([FromForm] FdImgRequest fdImgRequest)
        {
            var Fd = await context.FoodDrinks
                .Include(x=>x.FdImgs)
                .FirstOrDefaultAsync(x=>x.FdId.Equals(fdImgRequest.FdId));
            if (Fd == null) return NotFound();

            List<string> imageNames = await uploadFileService.UploadImages(fdImgRequest.formFiles); 
            foreach (var img in imageNames)
            {
                context.FdImgs.Add(new FdImg
                {
                    FdImgName = img,
                    FoodDrinkFdId = Fd.FdId,
                });
            }
             
            await context.SaveChangesAsync(); 
            return Ok(new { msg = "OK", Fd });

        }


        [HttpDelete("{id}")]
        public async Task<object> DeleteProductImage(Guid id)
        {
            try
            {
                return Ok(await fdImgService.Delete(id));
            }
            catch (Exception e)
            {
                return Constants.Return400(e.Message);
            }
        }


        //[HttpDelete("{id}")]
        //public async Task<ActionResult<FdImg>> DeleteProductImage(string id)
        //{
        //    //var Fdimg = await context.FdImgs.FirstOrDefaultAsync();
        //    try
        //    {

        //        return Ok(await fdImgService.Delete(id));
        //    }
        //    catch (Exception e)
        //    {
        //        return (ActionResult<FdImg>)Constants.Return400(e.Message);
        //    }
        //}



    }
}
