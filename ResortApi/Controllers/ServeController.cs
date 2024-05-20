using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.DTOS.Serve;
using ResortApi.Interface;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServeController : ControllerBase
    {
        private readonly IServeService serveService;

        public ServeController(IServeService serveService)
        {
            this.serveService = serveService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var show = await serveService.FindAll();

            return Ok(show);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromForm] ServeRequest data)
        {
            try
            {
                return Ok(await serveService.Create(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcmdById(int id)
        {
            //var ps = new ProductService(databaseContext);
            //var data = await ps.FindById(id);
            //return Ok(ProductResponse.FromProduct(data));
            try
            {
                return Ok(await serveService.FindById(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }




        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateAcmd([FromForm] ServeUpdate data)
        {
            try
            {
                return Ok(await serveService.Update(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteServe(int id)
        {
            try
            {
                object Acmd = await serveService.Delete(id);
                //object FdImage = await fdImgService.DeleteAll(id);
                return Ok(new { Acmd });
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }
    }
}
