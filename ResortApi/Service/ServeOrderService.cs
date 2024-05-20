using Mapster;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.Orders;
using ResortApi.DTOS.ServeOrderItems;
using ResortApi.DTOS.ServeOrders;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Models.OrderAggregate;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class ServeOrderService : IServeOrderService
    {

        private readonly DatabaseContext context;
        private readonly IUploadFileService uploadFileService;
        private readonly IServeCartService serveCartService;
        //private readonly ITransportationService transportationService;
        public ServeOrderService(DatabaseContext context, IUploadFileService uploadFileService, IServeCartService serveCartService
            //ITransportationService transportationService
            )
        {
            this.context = context;
            this.uploadFileService = uploadFileService;
            this.serveCartService = serveCartService;
            //this.transportationService = transportationService;
        }

        public async Task<object> CancelStatusServeOrder(string id)
        {
            var result = await context.ServeOrders.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            result.Status = PaymentStatus.CancelTransaction;
            context.ServeOrders.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }

        public async Task<object> ConfirmStatusServeOrder(string id)
        {
            var result = await context.ServeOrders.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            result.Status = PaymentStatus.SuccessfulTransaction;
            context.ServeOrders.Update(result);


            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }

        public async Task<object> ConfirmStatusPayment(string id)
        {
            var result = await context.ServeOrders.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            result.Status = PaymentStatus.WaitingForCheck;
            context.ServeOrders.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }

        public async Task<object> CreateServeOrder(ServeOrderCreate data)
        {
            if (data.ServeOrderItem.Count == 0) return Constants.Return400("เกิดข้อพิดพลาด");

            var errMsg = await OrderCheckStock(data.ServeOrderItem); //CheckStock
            if (!string.IsNullOrEmpty(errMsg)) return Constants.Return400(errMsg);

            #region New Order
            var newOrder = data.Adapt<ServeOrder>();
            newOrder.Id = Constants.DateId16();
            //newOrder.Status = PaymentStatus.WorkInProgress;
            newOrder.Status = PaymentStatus.WorkInProgress;
            newOrder.Isused = "1";
            //newOrder.CreateDate = DateTime.Now;
            #endregion  

            #region New OrderItem
            for (var i = 0; i < data.ServeOrderItem.Count; i++)
            {
                newOrder!.ServeOrderItem!.Skip(i).First().Id = Constants.uuid24();
                newOrder!.ServeOrderItem!.Skip(i).First().ServeOrderId = newOrder.Id;

                var product = await context.Services.FirstOrDefaultAsync(a => a.ServeId.Equals(newOrder!.ServeOrderItem!.Skip(i).First().ServeId));
                if (product is null) return Constants.Return400("เกิดข้อผิดพลาด");
                //product.Stock -= newOrder!.OrderItem!.Skip(i).First().Amount;
                //product.StockSell += newOrder!.OrderItem!.Skip(i).First().Amount;
                //context.Accommodations.Update(product);
                await serveCartService.DeleteServeCart(data.ServeOrderItem!.Skip(i).First().IdServeCart);
            }
            #endregion

            await context.ServeOrders.AddAsync(newOrder);
            await context.SaveChangesAsync();
            return Constants.Return200Id("บันทึกรายการสั่งสำเร็จ", newOrder.Id);
        }
        public async Task DeleteImage(string fileName)
        {
            await uploadFileService.DeleteImages(fileName);
        }

        public async Task UpdateServeOrder(ServeOrder ServeOrder)
        {
            context.Update(ServeOrder);
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

        public async Task<ServeOrder> GetByIdM(string id)
        {
            var result = await context.ServeOrders.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<object> GetByAccountId(string status, string accountId, int pageSize)
        {
            var query = context.ServeOrders

                //var query = context.Orders.Where(a => a.OrderItem.)

                //.Include(a => a.Transportation)
                //.Include(a => a.Address)
                //    .ThenInclude(a => a.Account)
                .Include(a => a.ServeOrderItem)
                    //.ThenInclude(a => a.AccountId)
                    .ThenInclude(a => a.Serve)
                        .ThenInclude(a => a.ServeImgs).ToList();
            // .Where(a => a.OrderItem..Equals(accountId))
            //.Where(a => a.Address.AccountId.Equals(accountId)).ToList();

            if (!string.IsNullOrEmpty(status)) query = query.Where(a => a.Status.Equals(status)).ToList();
            query = query.OrderByDescending(a => a.CreateDate).ToList();
            int count = query.Count;
            query = query.Take(pageSize).ToList();

            return Constants.Return200PaginData("success", new { status, count, pageSize, totalPage = (int)Math.Ceiling((double)count / pageSize), }, query.Select(ServeOrderResponse.OrdersProductOneImgOneTran));


        }

        public async Task<object> GetById(string id)
        {
            var result = await context.ServeOrders
                .Include(a => a.ServeOrderItem)
                    .ThenInclude(a => a.Serve)
                        .ThenInclude(a => a.ServeImgs)
                .Include(a => a.ServeOrderItem)

                .FirstOrDefaultAsync(a => a.Id.Equals(id));
            //result.Payment = result.Payment.OrderByDescending(a => a.Createdate).ToList();
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");
            return Constants.Return200Data("success", ServeOrderResponse.OrderItemsAccountAddressPaymentProductCateOneImgTran(result!));
        }

        public async Task<object> GetServeOrders(
            string status,
            int currentPage, int pageSize)
        {
            var query = context.ServeOrders
                //.Include(a => a.Transportation)
                .Include(e => e.ServeOrderItem)
                    .ThenInclude(e => e.Serve)
                        .ThenInclude(e => e.ServeImgs).ToList();
            // Status Query
            if (!string.IsNullOrEmpty(status)) query = query.Where(a => a.Status.Equals(status)).ToList();
            query = query.OrderByDescending(a => a.CreateDate).ToList();
            // Count Data
            int count = query.Count;
            // Query Data
            var data = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return Constants.Return200PaginData("success", new
            {
                //status,
                currentPage,
                pageSize,
                count,
                totalPage = (int)Math.Ceiling((double)count / pageSize),
            }, data.Select(ServeOrderResponse.OrdersProductOneImgOneTran));
        }

        public async Task<IEnumerable<ServeOrder>> GetTest()
        {
            var show = await context.ServeOrders
               //Include(x => x.ServeType).
               .Include(x => x.ServeOrderItem)
               .ToListAsync();

            return show;
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

        public async Task<object> SuccessStatusServeOrder(string id)
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
            var result = await context.ServeOrders
                //.Include(a => a.Address)
                .Include(a => a.ServeOrderItem)
                    .ThenInclude(a => a.Serve)
                //.Include(a => a.Payment)
                .OrderByDescending(a => a.CreateDate)
                .ToListAsync();
            return Constants.Return200Data("success", result.Select(ServeOrderResponse.OrderItemsAddressPaymentProduct));
        }





        private async Task<string> OrderCheckStock(List<ServeOrderItemCreate> ItemList)
        {
            string errMsg = string.Empty;
            foreach (var item in ItemList)
            {
                var result = await context.Services.FirstOrDefaultAsync(a => a.ServeId.Equals(item.ServeId));
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


