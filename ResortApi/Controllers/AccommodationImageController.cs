using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.Accommodation;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccommodationImageController : ControllerBase
    {
        private readonly DatabaseContext context;
        private readonly IUploadFileService uploadFileService;

        public AccommodationImageController(DatabaseContext context, IUploadFileService uploadFileService)
        {
            this.context = context;
            this.uploadFileService = uploadFileService;
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<AccommodationImg>> Create([FromForm] AcmdImgRequest acmdImgRequest)
        {
            var Acmd = await context.Accommodations
                .Include(x => x.AccommodationImgs)
                .FirstOrDefaultAsync(x => x.AccommodationId.Equals(acmdImgRequest.AcmdId));
            if (Acmd == null) return NotFound();

            List<string> imageNames = await uploadFileService.UploadImages(acmdImgRequest.formFiles);
            foreach (var img in imageNames)
            {
                context.AccommodationImgs.Add(new AccommodationImg
                {
                    Image = img,
                    AccommodationId = Acmd.AccommodationId,
                });
            }

            await context.SaveChangesAsync();
            return Ok(new { msg = "ok", Acmd });

        }


        [HttpDelete("{id}")]
        public async Task<object> Delete(Guid id)
        {
            var result = await context.AccommodationImgs.FindAsync(id);
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            await uploadFileService.DeleteImages(result.Image);
            context.AccommodationImgs.Remove(result);
            await context.SaveChangesAsync();
            return Constants.Return200("ลบสำเร็จ");
        }

        //[HttpDelete("{id}")]
        //public async Task<object> DeleteImage(Guid id)
        //{
        //    try
        //    {
        //        return Ok(await fdImgService.Delete(id));
        //    }
        //    catch (Exception e)
        //    {
        //        return Constants.Return400(e.Message);
        //    }
        //}




    }
}
