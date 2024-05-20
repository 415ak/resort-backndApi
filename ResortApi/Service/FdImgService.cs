
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Services
{
    internal class FdImgService : IFdImgService
    {
        private readonly IUploadFileService uploadFileService;
        private readonly DatabaseContext context;
        public FdImgService(IUploadFileService uploadFileService, DatabaseContext context)
        {
            this.uploadFileService = uploadFileService;
            this.context = context;
        }

        public async Task Create(FdImg FdImgId)
        {
            await context.FdImgs.AddAsync(FdImgId);
            await context.SaveChangesAsync();
            

        }

        public async Task<object> Delete(Guid id)
        {
            var result = await context.FdImgs.FindAsync(id);
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            await uploadFileService.DeleteImages(result.FdImgName);
            context.FdImgs.Remove(result);
            await context.SaveChangesAsync();
            return Constants.Return200("ลบสำเร็จ");
        }

        public async Task<object> DeleteAll(string id)
        {
            var result = await context.FdImgs.FindAsync(id);


            await uploadFileService.DeleteImages(result.FdImgName);
            context.FdImgs.Remove(result);
            await context.SaveChangesAsync();


            return Constants.Return200("ลบสำเร็จ");




        }

        //public async Task<object> Delete(string id)
        //{
        //    var result = await context.ProductImages.FindAsync(id);
        //    if (result is null) return Constants.Return400("ไม่พบข้อมูล");

        //    await uploadFileService.DeleteImage(result.Image);
        //    context.ProductImages.Remove(result);
        //    await context.SaveChangesAsync();
        //    return Constants.Return200("ลบสำเร็จ");
        //}

        //public async Task<IEnumerable<FdImg>> Get()
        //{
        //    var fdimgs = await context.FdImgs.ToListAsync();

        //    return fdimgs;
        //}

        public async Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles)
        {
            var errorMessage = string.Empty;
            var imageName = string.Empty;

            if (uploadFileService.IsUpload(formFiles))
            {
                errorMessage = uploadFileService.Validation(formFiles);
                if (string.IsNullOrEmpty(errorMessage))
                    imageName = (await uploadFileService.UploadImages(formFiles))[0];
            }
            return (errorMessage, imageName);
        }

        //public async Task<object> Delete(string id)
        //{
        //    var result = await context.ProductImages.FindAsync(id);
        //    if (result is null) return Constants.Return400("ไม่พบข้อมูล");

        //    await uploadFileService.DeleteImage(result.Image);
        //    context.ProductImages.Remove(result);
        //    await context.SaveChangesAsync();
        //    return Constants.Return200("ลบสำเร็จ");
        //}

        //Task<FdImg> IFdImgService.Delete(string id)
        //{
        //    var result = await context.FdImgs.FindAsync(id);
        //    if (result is null) return Constants.Return400("ไม่พบข้อมูล");

        //    await uploadFileService.DeleteImages(result.FdImgName);
        //    context.FdImgs.Remove(result);
        //    await context.SaveChangesAsync();
        //    return Constants.Return200("ลบสำเร็จ");
        //}
    }
}