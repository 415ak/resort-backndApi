using ResortApi.DTOS.OrderItems;
using ResortApi.DTOS.Orders;
//using ResortApi.DTOS.Transportations;
using ResortApi.Settings;
using ResortApi.Interfaces;
using ResortApi.Models;
using ResortApi.Models.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using ResortApi.Interface;

namespace ResortApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly DatabaseContext context;
        private readonly IUploadFileService uploadFileService;
        private readonly ICartItemService cartItemService;
        //private readonly ITransportationService transportationService;
        public OrderService(DatabaseContext context, IUploadFileService uploadFileService, ICartItemService cartItemService
            //ITransportationService transportationService
            )
        {
            this.context = context;
            this.uploadFileService = uploadFileService;
            this.cartItemService = cartItemService;
            //this.transportationService = transportationService;
        }

        public async Task<object> CancelStatusOrder(string id)
        {
            var result = await context.Orders.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //result.Status = "0";
            context.Orders.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }

        public async Task<object> ConfirmStatusOrder(string id)
        {
            var result = await context.Orders.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //result.Status = "3";
            context.Orders.Update(result);

            //var newTransportation = new TransportationCreate
            //{
            //    OrderId = result.Id,
            //    Status = "เตรียมพัสดุ",
            //    Detail = "ร้านจัดเตรียมพัสดุ"
            //};
            //await transportationService.CreateTransportation(newTransportation);

            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }

        public async Task<object> ConfirmStatusPayment(string id)
        {
            var result = await context.Orders.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //result.Status = "2";
            context.Orders.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }

        public async Task<object> CreateOrder(OrderCreate data)
        {
            if (data.OrderItem.Count == 0) return Constants.Return400("เกิดข้อพิดพลาด");

            var errMsg = await OrderCheckStock(data.OrderItem); //CheckStock
            if (!string.IsNullOrEmpty(errMsg)) return Constants.Return400(errMsg);

            #region New Order
            var newOrder = data.Adapt<Order>();
            newOrder.Id = Constants.DateId16();
            //newOrder.Account = data.account
            //newOrder.Status = "1";
            newOrder.Isused = "1";
            //newOrder.CreateDate = DateTime.Now;
            #endregion  

            #region New OrderItem
            for (var i = 0; i < data.OrderItem.Count; i++)
            {
                newOrder!.OrderItem!.Skip(i).First().Id = Constants.uuid24();
                newOrder!.OrderItem!.Skip(i).First().OrderId = newOrder.Id;

                var product = await context.FoodDrinks.FirstOrDefaultAsync(a => a.FdId.Equals(newOrder!.OrderItem!.Skip(i).First().FdId));
                if (product is null) return Constants.Return400("เกิดข้อผิดพลาด");
                //product.Stock -= newOrder!.OrderItem!.Skip(i).First().Amount;
                //product.StockSell += newOrder!.OrderItem!.Skip(i).First().Amount;
                context.FoodDrinks.Update(product);
                await cartItemService.DeleteCartItem(data.OrderItem!.Skip(i).First().IdCartItem);
            }
            #endregion

            await context.Orders.AddAsync(newOrder);
            await context.SaveChangesAsync();
            return Constants.Return200Id("บันทึกรายการสั่งสำเร็จ", newOrder.Id);
        }

        public async Task DeleteImage(string fileName)
        {
            await uploadFileService.DeleteImages(fileName);
        }

        public async Task UpdateOrder(Order Order)
        {
            context.Update(Order);
            await context.SaveChangesAsync();
        }

        public async Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles)
        {
            var errorMessage = string.Empty;
            //var imageName = new List<string>();
            var imageName = string.Empty;
            if (uploadFileService.IsUpload(formFiles))
            {
                errorMessage = uploadFileService.Validation(formFiles);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    imageName = (await uploadFileService.UploadImages(formFiles))[0];
                }
            }
            return (errorMessage, imageName);
        }

        public async Task<Order> GetByIdM(string id)
        {
            var result = await context.Orders.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<object> GetByAccountId(string status, string accountId, int pageSize)
        {
            var query = context.Orders

                //var query = context.Orders.Where(a => a.OrderItem.)

                //.Include(a => a.Transportation)
                //.Include(a => a.Address)
                //    .ThenInclude(a => a.Account)
                .Include(a => a.OrderItem)
                    //.ThenInclude(a => a.AccountId)
                    .ThenInclude(a => a.FoodDrink)
                        .ThenInclude(a => a.FdImgs)
            // .Where(a => a.OrderItem..Equals(accountId))
                        .Where(a => a.AccountId.Equals(accountId)).ToList();

            if (!string.IsNullOrEmpty(status)) query = query.Where(a => a.Status.Equals(status)).ToList();
            query = query.OrderByDescending(a => a.CreateDate).ToList();
            int count = query.Count;
            query = query.Take(pageSize).ToList();
            
            return Constants.Return200PaginData("success", new { status, count, pageSize, totalPage = (int)Math.Ceiling((double)count / pageSize), }, query.Select(OrderResponse.OrdersProductOneImgOneTran));


        }

        public async Task<object> GetById(string id)
        {
            var result = await context.Orders
                //.Include(a => a.Transportation)
                //.Include(a => a.Address)
                //    .ThenInclude(a => a.Account)
                .Include(a => a.OrderItem)
                    .ThenInclude(a => a.FoodDrink)
                        .ThenInclude(a => a.FdImgs)
                .Include(a => a.OrderItem)
                    .ThenInclude(a => a.FoodDrink)
                        .ThenInclude(a => a.FdCategory)
                //.Include(a => a.Payment)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));
            //result.Payment = result.Payment.OrderByDescending(a => a.Createdate).ToList();
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");
            return Constants.Return200Data("success", OrderResponse.OrderItemsAccountAddressPaymentProductCateOneImgTran(result!));
        }

        public async Task<object> GetOrders(string status, int currentPage, int pageSize)
        {
            var query = context.Orders
                //.Include(a => a.Transportation)
                .Include(e => e.OrderItem)
                    .ThenInclude(e => e.FoodDrink)
                        .ThenInclude(e => e.FdImgs).ToList();
            // Status Query
            if (!string.IsNullOrEmpty(status)) query = query.Where(a => a.Status.Equals(status)).ToList();
            query = query.OrderByDescending(a => a.CreateDate).ToList();
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
            }, data.Select(OrderResponse.OrdersProductOneImgOneTran));
        }

        public async Task<object> SuccessStatusOrder(string id)
        {
            var result = await context.Orders.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            //result.Status = "4";
            context.Orders.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }

        public async Task<object> GetForExcel()
        {
            var result = await context.Orders
                //.Include(a => a.Address)
                .Include(a => a.OrderItem)
                    .ThenInclude(a => a.FoodDrink)
                //.Include(a => a.Payment)
                .OrderByDescending(a => a.CreateDate)
                .ToListAsync();
            return Constants.Return200Data("success", result.Select(OrderResponse.OrderItemsAddressPaymentProduct));
        }

        private async Task<string> OrderCheckStock(List<OrderItemCreate> ItemList)
        {
            string errMsg = string.Empty;
            foreach (var item in ItemList)
            {
                var result = await context.FoodDrinks.FirstOrDefaultAsync(a => a.FdId.Equals(item.FdId));
                if (result is null) errMsg = "เกิดข้อพิดพลาด";
                //else if (result.Stock < item.Amount) errMsg = "สินค้าหมด";
            }
            return errMsg;
        }

        private async Task<(string errorMessage, string imageName)> UpLoadImage(IFormFileCollection formFiles)
        {
            string errorMessage = string.Empty;
            string imageName = string.Empty;
            if (uploadFileService.IsUpload(formFiles))
            {
                errorMessage = uploadFileService.Validation(formFiles);
                if (string.IsNullOrEmpty(errorMessage))
                    imageName = (await uploadFileService.UploadImages(formFiles))[0];
            }
            return (errorMessage, imageName);
        }

    }
}
