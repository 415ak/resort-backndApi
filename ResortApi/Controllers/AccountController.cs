using ResortApi.DTOS.Account;
using ResortApi.Models;
using ResortApi.Services;
using ResortApi.Settings;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpPost("Register/")]
        public async Task<IActionResult> Register([FromForm] RegisterRequest data)
        {
            try
            {
                return Ok(await accountService.Register(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }
        //public async Task<IActionResult> Register([FromForm] RegisterRequest registerRequset)
        //{
        //    var user = registerRequset.Adapt<User>();
        //    await accountService.Register(user);
        //    return Ok(new { msg = "OK" });
        //}


        //[HttpPost("[action]")]
        //public async Task<IActionResult> Login([FromForm] LoginRequest data)
        //{
        //    try
        //    {
        //        return Ok(await accountService.Login(data));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(Constants.Return400(e.Message));
        //    }
        //}

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromForm] LoginRequest data)
        {
            var result = await accountService.LoginShow(data);
            //var result = await accountService.Login(data);

            try
            {
                var token = accountService.GenerateToken(result);
                //return Ok(await accountService.Login(data));
                return Ok(new { msg = "OK", result, token });
                //return result
            }
            catch (Exception e)
            {
                return BadRequest(new { msg = "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง" });
            }
        }




        [HttpGet("GetUser/")]
        public async Task<IActionResult> GetUser()
        {
            var user = await accountService.FindAll();
            return Ok(user);
            //var result = User
            //             .OrderByDescending(p => p.AccountId).ToList();
            //return result;
        }

        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> GetByToken()
        {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                return Ok(await accountService.GetByToken(accessToken!));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        //[HttpGet("[action]")]
        //public async Task<ActionResult> Info()
        //{
        //    //อ่านค่า Token (คล้ายๆ การอ่าน session)
        //    var accessToken = await HttpContext.GetTokenAsync("access_token");
        //    if (accessToken == null) return Unauthorized();

        //    var account = accountService.GetInfo(accessToken);
        //    return Ok(new
        //    {
        //        id = account.AccountId,
        //        email = account.Email,
        //        role = account.Role.RoleName,
        //        name = account.FirstName,

        //    });
        //}

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetByToken()
        //{
        //    try
        //    {
        //        var userToken = await HttpContext.GetTokenAsync("access_token");
        //        return Ok(await accountService.GetByToken(userToken!));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(Constants.Return400(e.Message));
        //    }
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                //var result = await accountService.GetByID(AccountId);
                return Ok(await accountService.GetByID(id));

            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            try
            {
                return Ok(await accountService.DeleteAccount(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromForm] AccountUpdate data)
        {
            try
            {
                return Ok(await accountService.Update(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        //[HttpDelete("[action]")]
        //// [FromQuery] int id ใส่เต็มยศ
        //public async Task<ActionResult<Account>> DeleteUser([FromQuery] string id)
        //{
        //    var user = await accountService.GetByID(id);
        //    if (user == null) return Ok(new { msg = "ไม่พบสินค้า" });
        //    await accountService.DeleteAccount(result);
        //    //await accountService.DeleteImage(result.Image);
        //    return Ok(new { msg = "OK", data = result });
        //}

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetProduct()
        //{
        //    var product = (await ps.FindAll()).Select(ProductResponse.FromProduct);
        //    return Ok(product);
        //}

    }
}
