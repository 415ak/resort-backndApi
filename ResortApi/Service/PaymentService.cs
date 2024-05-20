using ResortApi.DTOS.Payments;
using ResortApi.Settings;
using ResortApi.Interfaces;
using ResortApi.Models;
using ResortApi.Models.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using ResortApi.Interface;
using ResortApi.Models.OrderAggregate;

namespace ResortApi.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DatabaseContext context;
        private readonly IUploadFileService uploadFileService;
        public PaymentService(DatabaseContext context, IUploadFileService uploadFileService)
        {
            this.context = context;
            this.uploadFileService = uploadFileService;
        }

        public async Task<object> GetByAccountId(string id)
        {
            var result = await context.Payments
                .Where(a => a.AccountId.Equals(id))
                .OrderByDescending(a => a.Createdate)
                .ToListAsync();
            return Constants.Return200CountData("success", result.Count, result.Select(PaymentResponse.Payment));
        }

        //public async Task<object> CreatePayment(PaymentCreate data)
        //{
        //    if (data.ImgPay is null) return Constants.Return400("เกิดข้อผิดพลาด");

        //    #region Check Image and Upload
        //    (string errorMessage, string imageName) = await UpLoadImage(data.ImgPay);
        //    if (!string.IsNullOrEmpty(errorMessage)) return Constants.Return400(errorMessage); 
        //    #endregion

        //    #region New Payment
        //    var newPayment = new Payment();
        //    newPayment.Id = Constants.DateId16();
        //    newPayment.ImgPay = imageName;
        //    newPayment.Status = "1";
        //    newPayment.Detail = data.Detail;
        //    newPayment.Createdate = DateTime.Now;
        //    newPayment.OrderId = data.OrderId;
        //    newPayment.ServeOrderId = data.ServeOrderId;
        //    newPayment.HbOrderId = data.HBOrderId;
        //    await context.Payments.AddAsync(newPayment);
        //    #endregion

        //    #region Change status order
        //    var order = await context.Orders.FindAsync(newPayment.OrderId);
        //    var HBorder = await context.HBOrders.FindAsync(newPayment.HbOrderId);
        //    var serveorder = await context.ServeOrders.FindAsync(newPayment.ServeOrderId);
        //    //if (HBorder is null) return Constants.Return400("ไม่พบข้อมูลคำสั่งซื้อ");
        //    //if (serveorder is null) return Constants.Return400("ไม่พบข้อมูลคำสั่งซื้อ");
        //    //if (order is null) return Constants.Return400("ไม่พบข้อมูลคำสั่งซื้อ");
        //    if (HBorder is null)
        //    {
        //        HBorder.Status = PaymentStatus.WaitingForCheck;
        //        context.HBOrders.Update(HBorder);
        //    }
        //    if (serveorder is null)
        //    {
        //        serveorder.Status = "2";
        //        context.ServeOrders.Update(serveorder);
        //    }
        //    if (order is null)
        //    {
        //        order.Status = "2";
        //        context.Orders.Update(order);
        //    }
        //    #endregion

        //    await context.SaveChangesAsync();
        //    return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        //}

        public async Task<object> CreatePayment(PaymentCreate data)
        {
            if (data.ImgPay is null) return Constants.Return400("เกิดข้อผิดพลาด");

            #region Check Image and Upload
            (string errorMessage, string imageName) = await UpLoadImage(data.ImgPay);
            if (!string.IsNullOrEmpty(errorMessage)) return Constants.Return400(errorMessage);
            #endregion

            #region New Payment
            var newPayment = new Payment();
            newPayment.Id = Constants.DateId16();
            newPayment.ImgPay = imageName;
            newPayment.Status = "1";
            newPayment.Detail = data.Detail;
            newPayment.Createdate = DateTime.Now;
            newPayment.AccountId = data.AccountId;
            newPayment.OrderId = data.OrderId;
            newPayment.ServeOrderId = data.ServeOrderId;
            newPayment.HbOrderId = data.HBOrderId;
            await context.Payments.AddAsync(newPayment);
            #endregion

            #region Change status order
            //var order = await context.Orders.FindAsync(newPayment.OrderId);
            //var HBorder = await context.HBOrders.FindAsync(newPayment.HbOrderId);
            //var serveorder = await context.ServeOrders.FindAsync(newPayment.ServeOrderId);

            //if (HBorder is null) return Constants.Return400("ไม่พบข้อมูลคำสั่งซื้อ");
            //if (serveorder is null) return Constants.Return400("ไม่พบข้อมูลคำสั่งซื้อ");
            //if (order is null) return Constants.Return400("ไม่พบข้อมูลคำสั่งซื้อ");

            //if (order is null)
            //{
            //    order.Status = "2";
            //    context.Orders.Update(order);
            //}

            //if (HBorder is null)
            //{
            //    HBorder.Status = PaymentStatus.WaitingForCheck;
            //    context.HBOrders.Update(HBorder);
            //}
            //if (serveorder is null)
            //{
            //    serveorder.Status = "2";
            //    context.ServeOrders.Update(serveorder);
            //}
            #endregion

            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        }


        //public async Task<object> CreatePayment(PaymentCreate data)
        //{
        //    //if (data.ImgPay is null) return Constants.Return400("เกิดข้อผิดพลาด");

        //    #region Check Image and Upload
        //    (string errorMessage, string imageName) = await UpLoadImage(data.ImgPay);
        //    if (!string.IsNullOrEmpty(errorMessage)) return Constants.Return400(errorMessage);
        //    #endregion

        //    #region New Payment
        //    var newPayment = new Payment();
        //    newPayment.Id = Constants.DateId16();
        //    newPayment.ImgPay = imageName;
        //    newPayment.Status = string.Empty;
        //    newPayment.Detail = string.Empty;
        //    newPayment.Createdate = DateTime.Now;

        //    //if(data.OrderId is null)
        //    //{
        //    //    newPayment.OrderId = "";
        //    //}
        //    //else 
        //    newPayment.OrderId = data.OrderId;

        //    //if (data.HBOrderId is null)
        //    //{
        //    //    newPayment.HbOrderId = "";

        //    //}
        //    //else 
        //    newPayment.HbOrderId = data.HBOrderId;

        //    //if (data.ServeOrderId is null)
        //    //{
        //    //    newPayment.ServeOrderId = "";

        //    //}
        //    //else 
        //    newPayment.ServeOrderId = data.ServeOrderId;

        //    //newPayment.ServeOrderId = data.ServeOrderId;
        //    //newPayment.HbOrderId = data.HBOrderId;
        //    await context.SaveChangesAsync();
        //    await context.Payments.AddAsync(newPayment);
        //    #endregion

        //    #region Change status order
        //    var order = await context.Orders.FindAsync(newPayment.OrderId);
        //    var HBorder = await context.HBOrders.FindAsync(newPayment.HbOrderId);
        //    var serveorder = await context.ServeOrders.FindAsync(newPayment.ServeOrderId);
        //    //if (HBorder is null) return Constants.Return400("ไม่พบข้อมูลคำสั่งซื้อ");
        //    //if (serveorder is null) return Constants.Return400("ไม่พบข้อมูลคำสั่งซื้อ");
        //    //if (order is null) return Constants.Return400("ไม่พบข้อมูลคำสั่งซื้อ");
        //    if (HBorder is not null)
        //    {
        //        HBorder.Status = PaymentStatus.WaitingForCheck;
        //        context.HBOrders.Update(HBorder);
        //        await context.SaveChangesAsync();

        //    }
        //    //if (HBorder is null)
        //    //{
        //    //    HBorder = "";
        //    //    //context.HBOrders.Update(HBorder);
        //    //}
        //    if (serveorder is not null)
        //    {
        //        serveorder.Status = "2";
        //        context.ServeOrders.Update(serveorder);
        //        await context.SaveChangesAsync();

        //    }
        //    if (order is not null)
        //    {
        //        order.Status = "2";
        //        context.Orders.Update(order);
        //        await context.SaveChangesAsync();

        //    }
        //    #endregion

        //    return Constants.Return200("บันทึกข้อมูลสำเร็จ");
        //}


        public async Task<object> UpdatePayment(Payment data)
        {
            var result = await context.Payments.FindAsync(data.Id);
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            result.Status = data.Status;
            //result.Detail = data.Detail;
            context.Payments.Update(result);
            await context.SaveChangesAsync();
            return Constants.Return200("บันทึกข้อมูลสำเร็จ");
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

        public async Task<IEnumerable<Payment>> GetAll()
        {
            var show = await context.Payments.
                Include(x => x.Account)
                //.Include(x => x.HbOrderId)
                //.Include(x=> x.ServeOrderId)
                //.Include(x=> x.OrderId)
                //.Include(x=> x.ImgPay)
                .ToListAsync();
            return show;
        }
        //    public async Task<IEnumerable<FoodDrink>> FindAll()
        //{
        //    var show = await context.FoodDrinks.
        //        Include(x => x.FdCategory).Include(x => x.FdImgs).ToListAsync();

        //    return show;
        //}
        public async Task<object> GetById(string id)
        {
            var result = await context.Payments.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (result is null) return Constants.Return400("ไม่พบข้อมูล");

            return Constants.Return200Data("OK", result);
        }
    }
}
