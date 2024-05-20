using ResortApi.DTOS.Orders;
using ResortApi.Settings;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc;
using ResortApi.Interfaces;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetForExcel()
        {
            try
            {
                return Ok(await orderService.GetForExcel());
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpGet("[action]/{id}")] 
        public async Task<IActionResult> GetById (string id)
        {
            try
            {
                return Ok(await orderService.GetById(id));
            } catch(Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrders(string? status = "", int currentPage = 1,int pageSize = 10)
        {
            try
            {
                return Ok(await orderService.GetOrders(status,currentPage,pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpGet("[action]/{accountId}")]
        public async Task<IActionResult> GetByAccountId(string accountId, [FromQuery]string? status = "",[FromQuery]int pageSize = 6)
        { 
            try
            {
                return Ok(await orderService.GetByAccountId(status, accountId, pageSize));
            } catch(Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrder([FromBody]OrderCreate data)
        {
            try
            {
                return Ok(await orderService.CreateOrder(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> PaymentOrder([FromForm] OrderPaymentRequest orderPaymentRequest)
        {
            var result = await orderService.GetByIdM(orderPaymentRequest.Id);
            if (result == null) return Ok(new { msg = "ไม่พบข้อมูล" });
            #region จัดการรูปภาพ
            (string erorrMesage, string imageName) = await orderService.UploadImage(orderPaymentRequest.FormFiles);
            if (!string.IsNullOrEmpty(erorrMesage)) return BadRequest(erorrMesage);
            if (!string.IsNullOrEmpty(imageName))
            {
                if (!string.IsNullOrEmpty(result.ImagePay)) await orderService.DeleteImage(result.ImagePay);
                result.ImagePay = imageName;
            }
            #endregion
            await orderService.UpdateOrder(result);
            return Ok(new { msg = "OK", data = result });
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ConfirmStatusPayment(string id)
        {
            try
            {
                return Ok(await orderService.ConfirmStatusPayment(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ConfirmStatusOrder(string id)
        {
            try
            {
                return Ok(await orderService.ConfirmStatusOrder(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> CancelStatusOrder(string id)
        {
            try
            {
                return Ok(await orderService.CancelStatusOrder(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> SuccessStatusOrder(string id)
        {
            try
            {
                return Ok(await orderService.SuccessStatusOrder(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

    }
}
