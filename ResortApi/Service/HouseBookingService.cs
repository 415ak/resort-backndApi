using Mapster;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.Accommodation;
using ResortApi.DTOS.HouseBooking;

using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class HouseBookingService : IHouseBookingService
    {
        private readonly DatabaseContext context;
        private readonly IAccommodationService accommodationService;

        public HouseBookingService(DatabaseContext context,IAccommodationService accommodationService)
        {
            this.context = context;
            this.accommodationService = accommodationService;
        }

        //public async Task<IEnumerable<HouseBooking>> GetAll()
        //{
        //    var show = await context.FdCategories.ToListAsync();

        //    return show;
        //}

        public async Task<object> GetAllHouseBooking(string status, int currentPage, int pageSize)
        {
            var query = context.HouseBookings
                //.Include(a => a.AccountId)
                .Include(b => b.Accommodation)
                    .ThenInclude(e => e.AccommodationImgs).ToList();
                //.Include(e => e.OrderItem)
                //    .ThenInclude(e => e.FoodDrink)
                //        .ThenInclude(e => e.FdImgs).ToList();
            // Status Query
            //if (!string.IsNullOrEmpty(status)) query = query.Where(a => a.Status.Equals(status)).ToList();
            query = query.OrderByDescending(c => c.CreateDate).ToList();
            // Count Data
            int count = query.Count;
            // Query Data
            var data = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return Constants.Return200PaginData("success", new
            {
                status,
                currentPage,
                pageSize,
                count,
                totalPage = (int)Math.Ceiling((double)count / pageSize),
            }, data.Select(HouseBookingResponse.BookingHouseCateOneImg));
        }

        public async Task<object> CreateHouseBooking(HouseBookingCreate data)
        {
            var result = await context.HouseBookings.FirstOrDefaultAsync(a =>
                     a.AccountId.Equals(data.AccountId) && a.AccommodationId.Equals(data.AccommodationId));
            var accommodation = await context.Accommodations.FirstOrDefaultAsync(a => a.AccommodationId.Equals(data.AccommodationId));
            if (accommodation is null) return Constants.Return400("ไม่พบสินค้า");
            if (result is not null)
            {
                if (accommodation.IsUsed != 1) 
                    return Constants.Return400("ที่พักไม่ว่าง");
                
                
                //result.Amount += data.Amount;
                //context.CartItems.Update(result);
            }
            else
            {
                //if (data.Amount > product!.Stock) return Constants.Return400("สินค้าไม่เพียงพอ");
                await accommodationService.ChangeStatus(data.AccommodationId);
                context.Accommodations.Update(accommodation);
                

                var newItem = data.Adapt<HouseBooking>();
                //newItem.CheckIn = DateTime.Now;
                //newItem.CheckOut = DateTime.Now;
                newItem.CreateDate = DateTime.Now;
                await context.HouseBookings.AddAsync(newItem);
            }
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }

        

        public async Task<object> DeleteHouseBooking(int id)
        {
            var result = await context.HouseBookings.Include(a => a.Accommodation).FirstOrDefaultAsync(a => a.Id.Equals(id));
            var accommodation = await context.Accommodations.FirstOrDefaultAsync(a => a.AccommodationId.Equals(result.AccommodationId));

            //var accommodation = await context.Accommodations.FirstOrDefaultAsync(a => a.AccommodationId.Equals(data.AccommodationId))
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            accommodation.IsUsed = 1;
            context.HouseBookings.Remove(result);
            await context.SaveChangesAsync();
            return Constants.Return200("ลบสินค้า");
        }

        public async Task<object> DeleteHouseBookingToOrder(int id)
        {
            var result = await context.HouseBookings.Include(a => a.Accommodation).FirstOrDefaultAsync(a => a.Id.Equals(id));
            var accommodation = await context.Accommodations.FirstOrDefaultAsync(a => a.AccommodationId.Equals(result.AccommodationId));

            //var accommodation = await context.Accommodations.FirstOrDefaultAsync(a => a.AccommodationId.Equals(data.AccommodationId))
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //accommodation.IsUsed = 1;
            context.HouseBookings.Remove(result);
            await context.SaveChangesAsync();
            return Constants.Return200("ลบสินค้า");
        }

        public async Task<object> GetBookHouseByAccountId(string id)
        {
            var result = await context.HouseBookings.Where(a => a.AccountId.Equals(id))
                   .Include(a => a.Accommodation)
                       .ThenInclude(a => a.AccommodationType)
                   .Include(a => a.Accommodation)
                       .ThenInclude(a => a.AccommodationImgs)
                   .ToListAsync();
            return new
            {
                statusCode = 200,
                message = "success",
                //total = result.Sum(a => a.Amount * a.FoodDrink.FdPrice),
                data = result.Select(HouseBookingResponse.BookingHouseCateOneImg)
            };
        }
    }
}
