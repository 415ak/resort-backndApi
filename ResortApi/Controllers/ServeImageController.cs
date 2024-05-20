using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.Serve;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServeImageController : ControllerBase
    {

        private readonly DatabaseContext context;
        private readonly IUploadFileService uploadFileService;

        public ServeImageController(DatabaseContext context, IUploadFileService uploadFileService)
        {
            this.context = context;
            this.uploadFileService = uploadFileService;
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<ServeImg>> Create([FromForm] ServeImgRequest serveImgRequest)
        {
            var ser = await context.Services
                .Include(x => x.ServeImgs)
                .FirstOrDefaultAsync(x => x.ServeId.Equals(serveImgRequest.serveId));
            if (ser == null) return NotFound();

            List<string> imageNames = await uploadFileService.UploadImages(serveImgRequest.formFiles);
            foreach (var img in imageNames)
            {
                context.ServiceImgs.Add(new ServeImg
                {
                    
                    Image = img,
                    //AccommodationId = Acmd.AccommodationId,
                    ServeId = ser.ServeId
                });
            }

            await context.SaveChangesAsync();
            return Ok(new { msg = "ok", ser });

        }



        //[HttpPost]
        //public async Task<ActionResult<AccommodationImg>> Create([FromForm] IFormFileCollection formFiles, string AcmdId)
        //{
        //    var Acmd = await context.Accommodations
        //        .Include(x => x.AccommodationImgs)
        //        .FirstOrDefaultAsync(x => x.AccommodationId.Equals(AcmdId));
        //    if (Acmd == null) return NotFound();

        //    List<string> imageNames = await uploadFileService.UploadImages(formFiles);
        //    foreach (var img in imageNames)
        //    {
        //        context.AccommodationImgs.Add(new AccommodationImg
        //        {
        //            Image = img,
        //            AccommodationId = Acmd.AccommodationId,
        //        });
        //    }

        //    await context.SaveChangesAsync();
        //    return Ok(new { msg = "ok", Acmd });

        //}


        [HttpDelete("{id}")]
        public async Task<object> Delete(Guid id)
        {
            var result = await context.ServiceImgs.FindAsync(id);
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            await uploadFileService.DeleteImages(result.Image);
            context.ServiceImgs.Remove(result);
            await context.SaveChangesAsync();
            return Constants.Return200("ลบสำเร็จ");
        }





    }
}


