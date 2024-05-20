using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.DTOS.HBOrders;
using ResortApi.Interface;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HBOrderController : ControllerBase
    {
        private readonly DatabaseContext context;

        private readonly IHBOrderService hborderService;
        public HBOrderController(IHBOrderService hborderService)
        {
            this.context = context;

            this.hborderService = hborderService;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetForExcel()
        {
            try
            {
                return Ok(await hborderService.GetForExcel());
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
                return Ok(await hborderService.GetById(id));
            } catch(Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByIdStatus(string id)
        {
            try
            {
                return Ok(await hborderService.GetByIdStatus(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetHBOrders(string? status = "", int currentPage = 1,int pageSize = 10)
        {
            try
            {
                return Ok(await hborderService.GetHBOrders(status,currentPage,pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> PaymentOrder([FromForm] HBOrderPaymentRequest hborderPaymentRequest)
        {
            var result = await hborderService.GetByIdM(hborderPaymentRequest.Id);
            if (result == null) return Ok(new { msg = "ไม่พบข้อมูล" });
            #region จัดการรูปภาพ
            (string erorrMesage, string imageName) = await hborderService.UploadImage(hborderPaymentRequest.FormFiles);
            if (!string.IsNullOrEmpty(erorrMesage)) return BadRequest(erorrMesage);
            if (!string.IsNullOrEmpty(imageName))
            {
                if (!string.IsNullOrEmpty(result.ImagePay)) await hborderService.DeleteImage(result.ImagePay);
                result.ImagePay = imageName;
            }
            #endregion
            await hborderService.UpdateHBOrder(result);

            var result1 = await hborderService.ConfirmStatusPayment(hborderPaymentRequest.Id);
            //result.Status = Models.OrderAggregate.PaymentStatus.WaitingForCheck;
            //await context.SaveChangesAsync();

            return Ok(new { msg = "OK", data = result });
        }


        [HttpGet("[action]/{accountId}")]
        public async Task<IActionResult> GetByAccountId(string accountId, [FromQuery]string? status = "",[FromQuery]int pageSize = 6)
        { 
            try
            {
                return Ok(await hborderService.GetByAccountId(status, accountId, pageSize));
            } catch(Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpGet("[action]/{accountId}")]
        public async Task<IActionResult> GetByAccountIdV2(string accountId, [FromQuery] string? status = "", [FromQuery] int pageSize = 6)
        {
            try
            {
                return Ok(await hborderService.GetByAccountIdV2(status, accountId, pageSize));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateHBOrder([FromBody]HBOrderCreate data)
        {
            try
            {
                return Ok(await hborderService.CreateHBOrder(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]/")]
        public async Task<IActionResult> ConfirmStatusPayment(string id)
        {
            try
            {
                return Ok(await hborderService.ConfirmStatusPayment(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }
        [HttpPut("[action]/")]
        public async Task<IActionResult> ConfirmStatusOrder(string id)
        {
            try
            {
                return Ok(await hborderService.ConfirmStatusHBOrder(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }
        [HttpPut("[action]/")]
        public async Task<IActionResult> CancelStatusOrder(string id)
        {
            try
            {
                return Ok(await hborderService.CancelStatusHBOrder(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }
        [HttpPut("[action]/")]
        public async Task<IActionResult> SuccessStatusOrder(string id)
        {
            try
            {
                return Ok(await hborderService.SuccessStatusHBOrder(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

    }
}
