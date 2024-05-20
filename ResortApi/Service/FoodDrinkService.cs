using Mapster;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.FoodDrinks;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class FoodDrinkService : IFoodDrinkService
    { 
        private readonly DatabaseContext context;
        private readonly IUploadFileService uploadFileService;
        private readonly IFdImgService fdImgService;

        public FoodDrinkService(DatabaseContext databaseContext, IUploadFileService uploadFileService, IFdImgService fdImgService)
        {
            this.context = databaseContext;
            this.uploadFileService = uploadFileService;
            this.fdImgService = fdImgService;
        }

        public async Task<IEnumerable<FoodDrink>> FindAll()
        {
            var show = await context.FoodDrinks.
                Include(x => x.FdCategory).Include(x => x.FdImgs).ToListAsync();

            return show;
        }
        //public async Task<object> GetOrders(string status, int currentPage, int pageSize)
        //{
        //    var query = context.Orders
        //        //.Include(a => a.Transportation)
        //        .Include(e => e.OrderItem)
        //            .ThenInclude(e => e.FoodDrink)
        //                .ThenInclude(e => e.FdImgs).ToList();
        //    // Status Query
        //    if (!string.IsNullOrEmpty(status)) query = query.Where(a => a.Status.Equals(status)).ToList();
        //    query = query.OrderByDescending(a => a.CreateDate).ToList();
        //    // Count Data
        //    int count = query.Count;
        //    // Query Data
        //    var data = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        //    return Constants.Return200PaginData("success", new
        //    {
        //        status,
        //        currentPage,
        //        pageSize,
        //        count,
        //        totalPage = (int)Math.Ceiling((double)count / pageSize),
        //    }, data.Select(OrderResponse.OrdersProductOneImgOneTran));
        //}


        public async Task<object> GetFoodDrinks()
        {

            var query = context.FoodDrinks
                .Include(e => e.FdCategory)
                .Include(e => e.FdImgs)
                .Where(a => a.FdIsused.Equals(1));

            // Query by CreateDate last
            query = query.OrderByDescending(a => a.DateTime);


            var data = query.ToList();

            return Constants.Return200Data("success", data.Select(FdResponse.FoodDrinkCateImages));

        }


        //public async Task<object> GetProducts(int currentPage, int pageSize, string categoryId, string search)
        //{
        //    var query = context.FoodDrinks.Include(e => e.FdCategory).Include(e => e.FdImgs)
        //        .Where(a => a.FdIsused.Equals("1"));

        //    // Category Check
        //    var category = await context.FdCategories.FirstOrDefaultAsync(a => a.FdCategoryId.Equals(categoryId));
        //    if (category is not null) query = query.Where(a => a.FdCategoryId.Equals(categoryId));
        //    // Query by CreateDate last
        //    query = query.OrderByDescending(a => a.DateTime);
        //    // Search Check
        //    if (!string.IsNullOrEmpty(search)) query = query.Where(a => a.FdName.Contains(search));
        //    // Count Data
        //    int count = query.Count();
        //    // Query Data
        //    var data = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        //    return Constants.Return200PaginData("success", new
        //    {
        //        category = category is not null ? category.Name : null,
        //        currentPage,
        //        pageSize,
        //        count,
        //        totalPage = (int)Math.Ceiling((double)count / pageSize),
        //        search
        //    }, data.Select(FdResponse.FoodDrinkCateImages));
        //}

        public async Task<object> Create(FdRequest data)
        {
            #region New Product
            var newProduct = data.Adapt<FoodDrink>();
            newProduct.FdId = Constants.uuid24();
            newProduct.DateTime = DateTime.Now;
            newProduct.FdIsused = 1;
            await context.FoodDrinks.AddAsync(newProduct);
            #endregion

            //#region Check Image and UpLoadImage
            //(string errorMessage, List<string> imageListName) = await UpLoadImage(data.upfile!);
            //if (!string.IsNullOrEmpty(errorMessage)) return Constants.Return400(errorMessage);
            //#endregion

            //#region AddProductImage
            //if (imageListName.Count > 0)
            //    foreach (var img in imageListName)
            //        await context.FdImgs.AddAsync(new FdImg
            //        {
            //            FdImgId = Constants.NewIdImage(),
            //            FdImgName = img,
            //            CreateDate = DateTime.Now,
            //            //FdId = newProduct.FdId,
            //        });
            //#endregion

            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลเร็จ");
            //await context.Products.AddAsync(data);
            //await context.SaveChangesAsync();
            
        }

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

        public async Task Delete(FoodDrink product)
        {
            context.FoodDrinks.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<object> DeleteFoodDrink(string id)
        {
            var result = await context.FoodDrinks.FindAsync(id);
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //result.FdIsused = 0;
            //context.FoodDrinks.Update(result);
            context.FoodDrinks.Remove(result);
            await context.SaveChangesAsync();
            return Constants.Return200("ลบข้อมูลสำเร็จ");
        }

        public async Task DeleteImage(string fileName)
        {
            await uploadFileService.DeleteImages(fileName);
        }

        public async Task<FoodDrink> FindById(string id)
        {
            var data = await context.FoodDrinks.Include(x => x.FdCategory).Include(x => x.FdImgs).
                FirstOrDefaultAsync((x => x.FdId.Equals(id)));
            if (data is null) return (FoodDrink)Constants.Return400("ไม่พบข้อมูล");
            return data;
        }

        public async Task<FoodDrink> FindById1(string id)
        {
            var data = await context.FoodDrinks.Include(x => x.FdCategory).
                FirstOrDefaultAsync((x => x.FdId.Equals(id)));
            return data;
        }



        public async Task<IEnumerable<FoodDrink>> Search(string name)
        {
            var data = await context.FoodDrinks.Where(x => x.FdName.Contains(name))
                .Include(x => x.FdCategory).ToListAsync();

            return data;
        }

        public async Task<object> Update(FdUpdate data)
        {
            var result = await context.FoodDrinks.SingleOrDefaultAsync(a => a.FdId.Equals(data.FdId));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            data.Adapt(result);
            #region Check Image and UpLoadImage
            (string errorMessage, List<string> imageListName) = await UpLoadImage(data.upfile);
            if (!string.IsNullOrEmpty(errorMessage)) return Constants.Return400(errorMessage);
            #endregion

            #region AddProductImage
            if (imageListName.Count > 0)
                foreach (var img in imageListName)
                    await context.FdImgs.AddAsync(new FdImg
                    {
                        //FdImgId = Constants.NewIdImage(),
                        FdImgName = img,
                        CreateDate = DateTime.Now,
                        //FdId = result.FdId,
                    });
            #endregion

            context.FoodDrinks.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("อัพเดตข้อมูลสำเร็จ");
            //localdbContext.Products.Update(data);
            ////databaseContext.Products.Update(product);
            //await localdbContext.SaveChangesAsync();

        }
    }


}
