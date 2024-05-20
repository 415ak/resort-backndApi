using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.DTOS.ServeOrders;
using ResortApi.Interface;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServeOrderController : ControllerBase
    {
        private readonly IServeOrderService serOrderService;
        public ServeOrderController(IServeOrderService serOrderService)
        {
            this.serOrderService = serOrderService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetForExcel()
        {
            try
            {
                return Ok(await serOrderService.GetForExcel());
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                return Ok(await serOrderService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetOrders(string? status = "", int currentPage = 1, int pageSize = 10)
        {
            try
            {
                return Ok(await serOrderService.GetServeOrders(
                    status,
                    currentPage, pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }
        
        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetTest(string? status = "", int currentPage = 1, int pageSize = 10)
        //{
        //    try
        //    {
        //        return Ok(await serOrderService.GetTest());
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(Constants.Return400(e.Message));
        //    }
        //}

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTest()
        {
            var show = await serOrderService.GetTest();

            return Ok(show);
        }

        [HttpGet("[action]/{accountId}")]
        public async Task<IActionResult> GetByAccountId(string accountId, [FromQuery] string? status = "", [FromQuery] int pageSize = 6)
        {
            try
            {
                return Ok(await serOrderService.GetByAccountId(status, accountId, pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrder([FromBody] ServeOrderCreate data)
        {
            try
            {
                return Ok(await serOrderService.CreateServeOrder(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> PaymentOrder([FromForm] ServeOrderPaymentRequest serveorderPaymentRequest)
        {
            var result = await serOrderService.GetByIdM(serveorderPaymentRequest.Id);
            if (result == null) return Ok(new { msg = "ไม่พบข้อมูล" });
            #region จัดการรูปภาพ
            (string erorrMesage, string imageName) = await serOrderService.UploadImage(serveorderPaymentRequest.FormFiles);
            if (!string.IsNullOrEmpty(erorrMesage)) return BadRequest(erorrMesage);
            if (!string.IsNullOrEmpty(imageName))
            {
                if (!string.IsNullOrEmpty(result.ImagePay)) await serOrderService.DeleteImage(result.ImagePay);
                result.ImagePay = imageName;
            }
            #endregion
            await serOrderService.UpdateServeOrder(result);
            return Ok(new { msg = "OK", data = result });
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ConfirmStatusPayment(string id)
        {
            try
            {
                return Ok(await serOrderService.ConfirmStatusPayment(id));
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
                return Ok(await serOrderService.ConfirmStatusServeOrder(id));
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
                return Ok(await serOrderService.CancelStatusServeOrder(id));
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
                return Ok(await serOrderService.SuccessStatusServeOrder(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }
    }
}
