using Mapster;
using Microsoft.AspNetCore.Mvc;
using ResortApi.DTOS.ServeCart;
using ResortApi.Interface;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServeCartController : ControllerBase
    {
        private readonly IServeCartService serveCartService;
        public ServeCartController(IServeCartService serveCartService)
        {
            this.serveCartService = serveCartService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByAccountId(string id)
        {
            try
            {
                return Ok(await serveCartService.GetCartItemByAccountId(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCartItem([FromForm] ServeCartCreate data)
        {
            try
            {
                return Ok(await serveCartService.CreateServeCart(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]/")]
        public async Task<IActionResult> UpdateCartServe([FromForm] ServeCartUpdate data)
        {
            try
            {
                return Ok(await serveCartService.Update(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        //[HttpPut("[action]")]
        //public async Task<IActionResult> UpdateServeCart([FromForm] ServeCartCreate cartRequest)
        //{
        //    var cartCustomer = await serveCartService.GetCartItemByAccountId(cartRequest.AccountId);
        //    if (cartCustomer == null)
        //    {
        //        return Ok(new { msg = "ไม่พบสินค้า" });
        //    }
        //    var result = cartRequest.Adapt(cartCustomer);
        //    await serveCartService.Update(result);
        //    return Ok(new { msg = "OK" });
        //}

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

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteServeCart(int id)
        {
            try
            {
                return Ok(await serveCartService.DeleteServeCart(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }


    }
}
