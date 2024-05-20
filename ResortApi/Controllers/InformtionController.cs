using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResortApi.Interface;

namespace ResortApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformtionController : ControllerBase
    {
        private readonly IInformationService iiformtionService;

        //private readonly IServeService serveService;

        public InformtionController(IInformationService iiformtionService)
        {
            this.iiformtionService = iiformtionService;
            //this.iiformtionService = iiformtionService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var show = await iiformtionService.FindAll();

            return Ok(show);
        }
    }
}
