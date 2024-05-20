using Mapster;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.CartItems;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class CartItemService : ICartItemService
    {
            private readonly DatabaseContext context;
            public CartItemService(DatabaseContext context)
            {
                this.context = context;
            }

            public async Task<object> CreateCartItem(CartItemCreate data)
            {
                var result = await context.CartItems.FirstOrDefaultAsync(a =>
                    a.AccountId.Equals(data.AccountId) && a.FdId.Equals(data.FdId));
                var product = await context.FoodDrinks.FirstOrDefaultAsync(a => a.FdId.Equals(data.FdId));
                if (product is null) return Constants.Return400("ไม่พบสินค้า");
                if (result is not null)
                {
                    //if (data.Amount + result.Amount > product!.Stock) return Constants.Return400("สินค้าไม่เพียงพอ");

                    result.Amount += data.Amount;
                    context.CartItems.Update(result);
                }
                else
                {
                    //if (data.Amount > product!.Stock) return Constants.Return400("สินค้าไม่เพียงพอ");
                    var newItem = data.Adapt<CartItem>();
                    newItem.CreateDate = DateTime.Now;
                    await context.CartItems.AddAsync(newItem);
                }
                await context.SaveChangesAsync();
                return Constants.Return200("บันทึกข้อมูลสำเร็จ");
            }


            public async Task<object> DeleteCartItem(int id)
            {
                var result = await context.CartItems.Include(a => a.FoodDrink).FirstOrDefaultAsync(a => a.Id.Equals(id));
                if (result is null) return Constants.Return400("ไม่พบข้อมูล");

                context.CartItems.Remove(result);
                await context.SaveChangesAsync();
                return Constants.Return200("ลบสินค้า");
            }

            public async Task<object> GetCartItemByAccountId(string id)
            {
                var result = await context.CartItems.Where(a => a.AccountId.Equals(id))
                    .Include(a => a.FoodDrink)                    
                        .ThenInclude(a => a.FdCategory)
                    .Include(a => a.FoodDrink)
                        .ThenInclude(a => a.FdImgs)
                    .ToListAsync();
                return new
                {
                    statusCode = 200,
                    message = "success",
                    total = result.Sum(a => a.Amount * a.FoodDrink.FdPrice),
                    data = result.Select(CartItemResponse.CartItemProductCateOneImg)
                };
            }

            

            public async Task<object> ItemPlus(CartItemPR data)
            {
                var result = await context.CartItems.Include(a => a.FoodDrink).FirstOrDefaultAsync(a => a.Id.Equals(data.Id));
                if (result is null) return Constants.Return400("ไม่พบข้อมูล");
                //if (result.Amount >= result.FoodDrink.Stock) return Constants.Return400("สินค้าไม่เพียงพอ");

                result.Amount = result.Amount += 1;
                context.CartItems.Update(result);
                await context.SaveChangesAsync();
                return Constants.Return200("เพิ่มจำนวนสำเร็จ");
            }

            public async Task<object> ItemRemove(CartItemPR data)
            {
                var result = await context.CartItems.Include(a => a.FoodDrink).FirstOrDefaultAsync(a => a.Id.Equals(data.Id));
                if (result is null) return Constants.Return400("ไม่พบข้อมูล");
                if (result.Amount <= 1) return Constants.Return400("เกิดข้อผิดพลาด ไม่สามารถลบข้อมูล");

                result.Amount = result.Amount -= 1;
                context.CartItems.Update(result);
                await context.SaveChangesAsync();
                return Constants.Return200("ลบจำนวนสำเร็จ");
            }

        }
}