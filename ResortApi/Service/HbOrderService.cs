using Mapster;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.HBOrderItems;
using ResortApi.DTOS.HBOrders;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Models.OrderAggregate;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class HbOrderService : IHBOrderService
    {
        private readonly DatabaseContext context;
        private readonly IUploadFileService uploadFileService;
        private readonly IHouseBookingService hbService;
        //private readonly ITransportationService transportationService;
        public HbOrderService(DatabaseContext context, IUploadFileService uploadFileService, IHouseBookingService hbService
            //ITransportationService transportationService
            )
        {
            this.context = context;
            this.uploadFileService = uploadFileService;
            this.hbService = hbService;
            //this.transportationService = transportationService;
        }

        public async Task<object> CancelStatusHBOrder(string id)
        {
            var result = await context.HBOrders.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            result.Status = PaymentStatus.CancelTransaction;
            context.HBOrders.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }


        public async Task<object> ConfirmStatusHBOrder(string id)
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

        public async Task DeleteImage(string fileName)
        {
            await uploadFileService.DeleteImages(fileName);
        }

        public async Task UpdateHBOrder(HBOrder HBorder)
        {
            //var result = await context.HBOrders.FirstOrDefaultAsync(a => a.Id.Equals(HBorder.Id));

            //HBOrder.Status = PaymentStatus.WaitingForCheck;

            context.Update(HBorder);
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

        public async Task<object> ConfirmStatusPayment(string id)
        {
            var result = await context.HBOrders.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            result.Status = PaymentStatus.WaitingForCheck;
            context.HBOrders.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }
        public async Task<HBOrder> GetByIdM(string id)
        {
            var result = await context.HBOrders.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        public async Task<object> CreateHBOrder(HBOrderCreate data)
        {
            if (data.HBOrderItem.Count == 0) return Constants.Return400("เกิดข้อพิดพลาด");

            var errMsg = await OrderCheckStock(data.HBOrderItem); //CheckStock
            if (!string.IsNullOrEmpty(errMsg)) return Constants.Return400(errMsg);

            #region New Order
            var newOrder = data.Adapt<HBOrder>();
            newOrder.Id = Constants.DateId16();
            //newOrder.Status = PaymentStatus.WorkInProgress;
            newOrder.Isused = "1";
            //newOrder.CreateDate = DateTime.Now;
            #endregion  

            #region New OrderItem
            for (var i = 0; i < data.HBOrderItem.Count; i++)
            {
                newOrder!.HBOrderItem!.Skip(i).First().Id = Constants.uuid24();
                newOrder!.HBOrderItem!.Skip(i).First().HBOrderId = newOrder.Id;

                var product = await context.Accommodations.FirstOrDefaultAsync(a => a.AccommodationId.Equals(newOrder!.HBOrderItem!.Skip(i).First().AccommodationId));
                if (product is null) return Constants.Return400("เกิดข้อผิดพลาด");
                //product.Stock -= newOrder!.OrderItem!.Skip(i).First().Amount;
                //product.StockSell += newOrder!.OrderItem!.Skip(i).First().Amount;
                //context.Accommodations.Update(product);
                await hbService.DeleteHouseBookingToOrder(data.HBOrderItem!.Skip(i).First().IdHBooking);
            }
            #endregion

            await context.HBOrders.AddAsync(newOrder);
            await context.SaveChangesAsync();
            return Constants.Return200Id("บันทึกรายการสั่งสำเร็จ", newOrder.Id);
        }

        public async Task<object> GetByAccountId(string status, string accountId, int pageSize)
        {
            var query = context.HBOrders

                //var query = context.Orders.Where(a => a.OrderItem.)

                //.Include(a => a.Transportation)
                //.Include(a => a.Address)
                //    .ThenInclude(a => a.Account)
                .Include(a => a.HBOrderItem)
                    //.ThenInclude(a => a.AccountId)
                    .ThenInclude(a => a.Accommodation)
                        .ThenInclude(a => a.AccommodationImgs)
                        //.ToList();
            // .Where(a => a.OrderItem..Equals(accountId))
            .Where(a => a.AccountId.Equals(accountId)).ToList();

            if (!string.IsNullOrEmpty(status)) query = query.Where(a => a.Status.Equals(status)).ToList();
            query = query.OrderByDescending(a => a.CreateDate).ToList();
            int count = query.Count;
            query = query.Take(pageSize).ToList();

            return Constants.Return200PaginData("success", new { status, count, pageSize, totalPage = (int)Math.Ceiling((double)count / pageSize), }, query.Select(HBOrderResponse.HBOrdersProductOneImgOneTran));


        }
        public async Task<object> GetByAccountIdV2(string status, string accountId,int pageSize)
        {
            //var state= status = PaymentStatus.WorkInProgress;
            var query = context.HBOrders

                //var query = context.Orders.Where(a => a.OrderItem.)

                //.Include(a => a.Transportation)
                //.Include(a => a.Address)
                //    .ThenInclude(a => a.Account)
                .Include(a => a.HBOrderItem)
                    //.ThenInclude(a => a.AccountId)
                    .ThenInclude(a => a.Accommodation)
                        .ThenInclude(a => a.AccommodationImgs)
            //.ToList();
            //.Where(a => a.AccountId.Equals(accountId)).ToList();
            .Where(a => a.AccountId.Equals(accountId))
            .Where(a => a.Status.Equals(PaymentStatus.WorkInProgress)).ToList();

            if (!string.IsNullOrEmpty(status)) query = query.Where(a => a.Status.Equals(PaymentStatus.WorkInProgress)).ToList();
            query = query.OrderByDescending(a => a.CreateDate).ToList();
            int count = query.Count;
            query = query.Take(pageSize).ToList();

            return Constants.Return200PaginData("success", new { status, count, pageSize, totalPage = (int)Math.Ceiling((double)count / pageSize), }, query.Select(HBOrderResponse.HBOrdersProductOneImgOneTran));


        }

        //public async Task<object> GetCartItemByAccountId(string id)
        //{
        //    var result = await context.HBOrders.Where(a => a.HBOrderItem.AccountId.Equals(id))
        //        .Include(a => a.HBOrderItem)
        //            //.ThenInclude(a => a.AccountId)
        //            .ThenInclude(a => a.Accommodation)
        //                .ThenInclude(a => a.AccommodationImgs)
        //        .ToListAsync();
        //    return new
        //    {
        //        statusCode = 200,
        //        message = "success",
        //        total = result.Sum(a => a.Amount * a.FoodDrink.FdPrice),
        //        data = result.Select(HBOrderResponse.HBOrdersProductOneImgOneTran)
        //    };
        //}

        public async Task<object> GetById(string id)
        {
            var result = await context.HBOrders
                //.Include(a => a.Transportation)
                //.Include(a => a.Address)
                //    .ThenInclude(a => a.Account)
                .Include(a => a.HBOrderItem)
                    .ThenInclude(a => a.Accommodation)
                        .ThenInclude(a => a.AccommodationImgs)
                .Include(a => a.HBOrderItem)
                    .ThenInclude(a => a.Accommodation)
                        .ThenInclude(a => a.AccommodationType)
                //.Include(a => a.Payment)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));
            //result.Payment = result.Payment.OrderByDescending(a => a.Createdate).ToList();
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");
            return Constants.Return200Data("success", HBOrderResponse.OrderItemsAccountAddressPaymentProductCateOneImgTran(result!));
        }

        public async Task<object> GetByIdStatus(string id)
        {
            var result = await context.HBOrders
                //.Include(a => a.Transportation)
                //.Include(a => a.Address)
                //    .ThenInclude(a => a.Account)
                .Include(a => a.HBOrderItem)
                    .ThenInclude(a => a.Accommodation)
                        .ThenInclude(a => a.AccommodationImgs)
                .Include(a => a.HBOrderItem)
                    .ThenInclude(a => a.Accommodation)
                        .ThenInclude(a => a.AccommodationType)
                //.Include(a => a.Payment)
                .FirstOrDefaultAsync(a => a.Id.Equals(id));
            //result.Payment = result.Payment.OrderByDescending(a => a.Createdate).ToList();
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");
            if (result.Status == PaymentStatus.WorkInProgress) return Constants.Return200Data("success", HBOrderResponse.OrderItemsAccountAddressPaymentProductCateOneImgTran(result!));
            else return "การุณาจองที่พักก่อน";
            //return Constants.Return200Data("success", HBOrderResponse.OrderItemsAccountAddressPaymentProductCateOneImgTran(result!));
        }

        public async Task<object> GetHBOrders(string status, int currentPage, int pageSize)
        {
            var query = context.HBOrders
                //.Include(a => a.Transportation)
                .Include(e => e.HBOrderItem)
                    .ThenInclude(e => e.Accommodation)
                        .ThenInclude(e => e.AccommodationImgs).ToList();
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
            }, data.Select(HBOrderResponse.HBOrdersProductOneImgOneTran));
        }

        public async Task<object> SuccessStatusHBOrder(string id)
        {
            var result = await context.HBOrders.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            result.Status = PaymentStatus.SuccessfulTransaction;
            context.HBOrders.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }

        public async Task<object> GetForExcel()
        {
            var result = await context.HBOrders
                //.Include(a => a.Address)
                .Include(a => a.HBOrderItem)
                    .ThenInclude(a => a.Accommodation)
                    //.ThenInclude(a => a.AccommodationImgs)
                //.Include(a => a.Payment)
                .OrderByDescending(a => a.CreateDate)
                .ToListAsync();
            return Constants.Return200Data("success", result.Select(HBOrderResponse.OrderItemsAddressPaymentProduct));
        }

        private async Task<string> OrderCheckStock(List<HBOrderItemCreate> ItemList)
        {
            string errMsg = string.Empty;
            foreach (var item in ItemList)
            {
                var result = await context.Accommodations.FirstOrDefaultAsync(a => a.AccommodationId.Equals(item.AccommodationId));
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
