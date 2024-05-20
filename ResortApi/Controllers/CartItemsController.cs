using ResortApi.DTOS.CartItems;
using ResortApi.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.Interface;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class CartItemsController : ControllerBase
    {
        private readonly ICartItemService cartItemService;
        public CartItemsController(ICartItemService cartItemService)
        {
            this.cartItemService = cartItemService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetByAccountId(string id)
        {
            try
            {
                return Ok(await cartItemService.GetCartItemByAccountId(id));
            } catch(Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCartItem([FromForm]CartItemCreate data)
        {
            try
            {
                return Ok(await cartItemService.CreateCartItem(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            try
            {
                return Ok(await cartItemService.DeleteCartItem(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ItemPlus([FromForm]CartItemPR data)
        {
            try
            {
                return Ok(await cartItemService.ItemPlus(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ItemRemove([FromForm]CartItemPR data)
        {
            try
            {
                return Ok(await cartItemService.ItemRemove(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

    }
}
