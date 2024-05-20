using Mapster;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.Serve;
using ResortApi.Interface;
using ResortApi.Interfaces;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class ServeService : IServeService
    {
        private readonly DatabaseContext context;
        private readonly IUploadFileService uploadFileService;
        public ServeService(DatabaseContext context, IUploadFileService uploadFileService)
        {
            this.context = context;
            this.uploadFileService = uploadFileService;
        }

        public async Task<IEnumerable<Serve>> FindAll()
        {
            var show = await context.Services.
                //Include(x => x.ServeType).
                Include(x => x.ServeImgs).ToListAsync();

            return show;
        }

        public async Task<Serve> FindById(int id)
        {
            var data = await context.Services
                //.Include(x => x.ServeType)
                .Include(x => x.ServeImgs).
                 FirstOrDefaultAsync((x => x.ServeId.Equals(id)));
            if (data is null) return (Serve)Constants.Return400("ไม่พบข้อมูล");
            return data;
        }

        public async Task<object> Update(ServeUpdate data)
        {

            var result = await context.Services.SingleOrDefaultAsync(a => a.ServeId.Equals(data.ServeId));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            data.Adapt(result);


            context.Services.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("อัพเดตข้อมูลสำเร็จ");
        }

        public async Task<object> Delete(int id)
        {
            var result = await context.Services.FindAsync(id);
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //result.FdIsused = 0;
            //context.FoodDrinks.Update(result);
            context.Services.Remove(result);
            await context.SaveChangesAsync();
            return Constants.Return200("ลบข้อมูลสำเร็จ");
        }

        //public async Task<object> Delete(string id)
        //{
        //    var result = await context.Accommodations.FindAsync(id);
        //    if (result is null) return Constants.Return400("ไม่พบข้อมูล");

        //    //result.FdIsused = 0;
        //    //context.FoodDrinks.Update(result);
        //    context.Accommodations.Remove(result);
        //    await context.SaveChangesAsync();
        //    return Constants.Return200("ลบข้อมูลสำเร็จ");
        //}


        public async Task<object> Create(ServeRequest data)
        {

            //var result = await context.Services.FirstOrDefaultAsync(a => a.Username.Equals(data.Username));
            //if (result != null) return Constants.Return400("อีเมลผู้ใช้ซ้ำ");

            //#region Check and UploadImage
            //(string errorMessage, string imageName) = await UpLoadImage(data.ServeImage!);
            //if (!string.IsNullOrEmpty(errorMessage)) return Constants.Return400(errorMessage);
            //#endregion

            //(string passwordHash, string salt) = CreateHashPasswordAndSalt(data.Password);

            //#region New Account
            //Account newAccount = data.Adapt<Account>();
            //newAccount.Username = newAccount.Username.ToLower();
            //newAccount.Password = passwordHash;
            //newAccount.ProfileImage = imageName;
            //newAccount.Id = Constants.uuid18();
            //newAccount.CreateDate = DateTime.Now;
            //newAccount.Isused = "1";
            //#endregion

            //#region New Salt
            //SecurityAccount newSalt = new SecurityAccount
            //{
            //    AccountId = newAccount.Id,
            //    TruePassword = data.Password,
            //    Salt = salt
            //};
            //#endregion


            #region New Serve
            var newServe = data.Adapt<Serve>();
            //newServe.ServeId = Constants.uuid24();
            newServe.CreatedDate = DateTime.Now;
            newServe.IsUsed = 1;
            await context.Services.AddAsync(newServe);
            #endregion




            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลเร็จ");
        }

        //public async Task<object> Delete(string id)
        //{
        //    var result = await context.Accommodations.FindAsync(id);
        //    if (result is null) return Constants.Return400("ไม่พบข้อมูล");

        //    //result.FdIsused = 0;
        //    //context.FoodDrinks.Update(result);
        //    context.Accommodations.Remove(result);
        //    await context.SaveChangesAsync();
        //    return Constants.Return200("ลบข้อมูลสำเร็จ");
        //}


        //private async Task<(string errorMessage, string imageName)> UpLoadImage(IFormFileCollection formFiles)
        //{
        //    string errorMessage = string.Empty;
        //    string imageName = string.Empty;
        //    if (uploadFileService.IsUpload(formFiles))
        //    {
        //        errorMessage = uploadFileService.Validation(formFiles);
        //        if (string.IsNullOrEmpty(errorMessage))
        //            imageName = (await uploadFileService.UploadImages(formFiles))[0];
        //    }
        //    return (errorMessage, imageName);
        //}

        private async Task<(string errorMessage, string imageName)> UpLoadImage(IFormFileCollection formFiles)
        {
            string errorMessage = string.Empty;
            string imageName = string.Empty;
            if (uploadFileService.IsUpload(formFiles))
            {
                errorMessage = uploadFileService.Validation(formFiles);
                if (string.IsNullOrEmpty(errorMessage))
                    imageName = (await uploadFileService.UploadImage(formFiles))[0];
            }
            return (errorMessage, imageName);
        }




       


        //public async Task<object> Update(AcmdUpdate data)
        //{
        //    var result = await context.Accommodations.SingleOrDefaultAsync(a => a.AccommodationId.Equals(data.AccommodationId));
        //    if (result is null) return Constants.Return400("ไม่พบข้อมูล");

        //    data.Adapt(result);


        //    context.Accommodations.Update(result);
        //    await context.SaveChangesAsync();
        //    return Constants.Return200("อัพเดตข้อมูลสำเร็จ");
        //    //localdbContext.Products.Update(data);
        //    ////databaseContext.Products.Update(product);
        //    //await localdbContext.SaveChangesAsync();
        //}




    }
}
