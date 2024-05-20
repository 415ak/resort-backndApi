using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.FoodDrinks;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class FdCategoryService : IFdCategoryService
    {

        private readonly DatabaseContext context;
        public FdCategoryService(DatabaseContext context)
        {
            this.context = context;
        }
        public async Task<object> Create(FdCategoryRequest data)
        {
            await context.FdCategories.AddAsync(new FdCategory
            {
                FdCategoryId = Constants.uuid18(),
                DateTime = DateTime.Now,
                Name = data.Name,
                //CreatedDate = DateTime.Now,
                IsUsed = 1
            });
            await context.SaveChangesAsync();
            return data;
        }


        public async Task<IEnumerable<FdCategory>> GetAll()
        {
            var show = await context.FdCategories.ToListAsync();

            return show;
        }

        public async Task<object> Delete(string id)
        {
            var result = await context.FdCategories.FindAsync(id);
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //result.FdIsused = 0;
            //context.FoodDrinks.Update(result);
            context.FdCategories.Remove(result);
            await context.SaveChangesAsync();
            return Constants.Return200("ลบข้อมูลสำเร็จ");
        }


    }
}
