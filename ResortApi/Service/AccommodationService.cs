using Mapster;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.Accommodation;
using ResortApi.Interface;
using ResortApi.Interfaces;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class AccommodationService : IAccommodationService
    {
        private readonly DatabaseContext context;
        private readonly IUploadFileService uploadFileService;


        public AccommodationService(DatabaseContext context, IUploadFileService uploadFileService)
        {
            this.context = context;
            this.uploadFileService = uploadFileService;
        }
        public async Task<object> Create(AcmdRequest data)
        {
            #region New Accommodation
            var newAcmd = data.Adapt<Accommodation>();
            newAcmd.AccommodationId = Constants.uuid24();
            newAcmd.CreateTime = DateTime.Now;
            newAcmd.Status = "1";
            newAcmd.IsUsed = 1;
            await context.Accommodations.AddAsync(newAcmd);
            #endregion

            //#region New Product
            //var newProduct = data.Adapt<FoodDrink>();
            //newProduct.FdId = Constants.uuid24();
            //newProduct.DateTime = DateTime.Now;
            //newProduct.FdIsused = 1;
            //await context.FoodDrinks.AddAsync(newProduct);
            //#endregion




            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลเร็จ");
        }

        //public async Task Delete(Accommodation acmd)
        //{
        //    context.Accommodations.Remove(acmd);
        //    await context.SaveChangesAsync();
        //}

        public async Task<object> Delete(string id)
        {
            var result = await context.Accommodations.FindAsync(id);
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //result.FdIsused = 0;
            //context.FoodDrinks.Update(result);
            context.Accommodations.Remove(result);
            await context.SaveChangesAsync();
            return Constants.Return200("ลบข้อมูลสำเร็จ");
        }

        //public async Task Delete(FoodDrink product)
        //{
        //    context.FoodDrinks.Remove(product);
        //    await context.SaveChangesAsync();
        //}

        public async Task<IEnumerable<Accommodation>> FindAll()
        {
            var show = await context.Accommodations.
                Include(x => x.AccommodationType).Include(x => x.AccommodationImgs).ToListAsync();

            return show;
        }

        public async Task<Accommodation> FindById(string id)
        {
            var data = await context.Accommodations.Include(x => x.AccommodationType).Include(x => x.AccommodationImgs).
                 FirstOrDefaultAsync((x => x.AccommodationId.Equals(id)));
            if (data is null) return (Accommodation)Constants.Return400("ไม่พบข้อมูล");
            return data;
        }

        //public async Task<FoodDrink> FindById(string id)
        //{

        //}
        private async Task<(string errorMessage, List<string> imageListName)> UpLoadImage(IFormFileCollection formFiles)
        {
            string errorMessage = string.Empty;
            List<string> imageListName = new List<string>();
            if (uploadFileService.IsUpload(formFiles))
            {
                errorMessage = uploadFileService.Validation(formFiles);
                if (string.IsNullOrEmpty(errorMessage))
                    imageListName = await uploadFileService.UploadImages(formFiles);
            }
            return (errorMessage, imageListName);
        }


        public async Task<object> Update(AcmdUpdate data)
        {
            var result = await context.Accommodations.SingleOrDefaultAsync(a => a.AccommodationId.Equals(data.AccommodationId));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            data.Adapt(result);
            //#region Check Image and UpLoadImage
            //(string errorMessage, List<string> imageListName) = await UpLoadImage(data.upfile);
            //if (!string.IsNullOrEmpty(errorMessage)) return Constants.Return400(errorMessage);
            //#endregion

            //#region AddProductImage
            //if (imageListName.Count > 0)
            //    foreach (var img in imageListName)
            //        await context.FdImgs.AddAsync(new FdImg
            //        {
            //            //FdImgId = Constants.NewIdImage(),
            //            FdImgName = img,
            //            CreateDate = DateTime.Now,
            //            //FdId = result.FdId,
            //        });
            //#endregion

            context.Accommodations.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("อัพเดตข้อมูลสำเร็จ");
        }

        public async Task<object> ChangeStatus(string id)
        {
            var result = await context.Accommodations.SingleOrDefaultAsync(a => a.AccommodationId.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //data.Adapt(result);
            if(result.IsUsed == 1)
            {
              result.IsUsed = 0;
            }
            else result.IsUsed = 1;
            //result.IsUsed = 0;

            context.Accommodations.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("อัพเดตข้อมูลสำเร็จ");
        }

        public async Task<object> ChangeStatusDto(AcmdUpdateStatus data)
        {
            var result = await context.Accommodations.SingleOrDefaultAsync(a => a.AccommodationId.Equals(data.Id));
            
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //data.Adapt(result);
            if (result.IsUsed == 1)
            {
                result.IsUsed = 0;
            }
            else result.IsUsed = 1;
            //result.IsUsed = 0;

            context.Accommodations.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("อัพเดตข้อมูลสำเร็จ");
        }
    }
}
