using Mapster;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.ServeCart;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class ServeCartService : IServeCartService
    {
        private readonly DatabaseContext context;
        public ServeCartService(DatabaseContext context)
        {
            this.context = context;
        }
        public async Task<object> CreateServeCart(ServeCartCreate data)
        {
            var result = await context.ServeCarts.FirstOrDefaultAsync(a =>
               a.AccountId.Equals(data.AccountId) && a.ServeId.Equals(data.ServeId));
            var product = await context.Services.FirstOrDefaultAsync(a => a.ServeId.Equals(data.ServeId));
            if (product is null) return Constants.Return400("ไม่พบสินค้า");
            //Console.WriteLine(result);
            if(result != null)
            {
                if (data.ServeId == result.ServeId) return Constants.Return400("เรียกใช้ไปแล้ว");

            }

            //result.Amount += data.Amount;
            //context.ServeCarts.Update(result);
            var newItem = data.Adapt<ServeCart>();
                newItem.CreateDate = DateTime.Now;
                await context.ServeCarts.AddAsync(newItem);
            
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }

        public async Task<object> Update(ServeCartUpdate data)
        {
            var result = await context.ServeCarts.SingleOrDefaultAsync(a => a.Id.Equals(data.Id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            data.Adapt(result);

            context.ServeCarts.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("อัพเดตข้อมูลสำเร็จ");
        }

        //[HttpPut("[action]")]
        //public async Task<IActionResult> UpdateCartCustomer([FromForm] CartRequest cartRequest)
        //{
        //    var cartCustomer = await cartService.GetByID(cartRequest.ID);
        //    if (cartCustomer == null)
        //    {
        //        return Ok(new { msg = "ไม่พบสินค้า" });
        //    }
        //    var result = cartRequest.Adapt(cartCustomer);
        //    await cartService.Update(result);
        //    return Ok(new { msg = "OK" });
        //}

        public async Task<object> DeleteServeCart(int id)
        {
            var result = await context.ServeCarts.Include(a => a.Serve).FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            context.ServeCarts.Remove(result);
            await context.SaveChangesAsync();
            return Constants.Return200("ลบสินค้า");
        }

        public async Task<object> GetCartItemByAccountId(string id)
        {
            var result = await context.ServeCarts.Where(a => a.AccountId.Equals(id))
                //.Include(a => a.Serve)
                    //.ThenInclude(a => a.FdCategory)
                .Include(a => a.Serve)
                    .ThenInclude(a => a.ServeImgs)
                .ToListAsync();
            return new
            {
                statusCode = 200,
                message = "success",
                total = result.Sum(a => a.Amount * a.Serve.Price),
                data = result.Select(ServeCartResponse.CartItemProductCateOneImg)
            };
        }








        
    }
}
