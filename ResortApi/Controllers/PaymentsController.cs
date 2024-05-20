using ResortApi.DTOS.Payments;
using ResortApi.Settings;
using ResortApi.Interface;
using ResortApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        public PaymentsController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var show = await paymentService.GetAll();

            return Ok(show);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByAccountId(string id)
        {
            try
            {
                return Ok(await paymentService.GetByAccountId(id));
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
                return Ok(await paymentService.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreatePayment([FromForm]PaymentCreate data)
        {
            try
            {
                return Ok(await paymentService.CreatePayment(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdatePayment([FromForm]Payment data)
        {
            try
            {
                return Ok(await paymentService.UpdatePayment(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

    }
}
