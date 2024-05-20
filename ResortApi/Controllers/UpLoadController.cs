//using Microsoft.AspNetCore.Mvc;
//using ResortApi.Interfaces;
//using ResortApi.Models.Data;

//namespace ResortApi.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class UpLoadController : ControllerBase
//    {

//        private readonly DatabaseContext context;
//        private readonly IFdImgService fdImgService;
//        private readonly IUploadFileService uploadFileService;

//        public UpLoadController(DatabaseContext context, IUploadFileService uploadFileService)
//        {
//            this.context = context;
//            this.uploadFileService = uploadFileService;
            
//        }


//        [HttpPost]
//        public async Task<ActionResult<FdImg>> Create([FromForm] IFormFileCollection formFiles, string prodeuctId)
//        {
//            var Fd = await context.FoodDrinks
//                .Include(x => x.FdImgs)
//                .FirstOrDefaultAsync(x => x.FdId.Equals(prodeuctId));
//            if (Fd == null) return NotFound();

//            List<string> imageNames = await uploadFileService.UploadImages(formFiles);
//            foreach (var img in imageNames)
//            {
//                context.FdImgs.Add(new FdImg
//                {
//                    FdImgName = img,
//                    FoodDrinkFdId = Fd.FdId,
//                });
//            }

//            await context.SaveChangesAsync();
//            return Ok(new { msg = "ok", Fd });

//        }


//    }
//}
