using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.FoodDrinks;
using ResortApi.Interface;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FoodDrinkController : ControllerBase
    {
        private readonly DatabaseContext context;
        private readonly IFoodDrinkService fd;
        private readonly IFdImgService fdImgService;

        public FoodDrinkController(DatabaseContext context, IFoodDrinkService fdService, IFdImgService fdImgService)
        {
            this.context = context;
            this.fd = fdService;
            this.fdImgService = fdImgService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var show = await fd.FindAll();
            return Ok(show);
            //var result = User
            //             .OrderByDescending(p => p.AccountId).ToList();
            //return result;
        }

        //[HttpGet("[action]")]
        //public async Task<IActionResult> GetProducts(int currentPage = 1, int pageSize = 10, string categoryId = "", string? search = "")
        //{
        //    try
        //    {
        //        return Ok(await fd.GetProducts(currentPage, pageSize, categoryId, search!));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(Constants.Return400(e.Message));
        //    }
        //}

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFoodDrink()
        //public async Task<IActionResult> GetProducts(int currentPage = 1, int pageSize = 10, int categoryId = 0, string? search = "")
        {
            try
            {
                return Ok(await fd.GetFoodDrinks());
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }



        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetFdById(string id)
        {
            //var ps = new ProductService(databaseContext);
            //var data = await ps.FindById(id);
            //return Ok(ProductResponse.FromProduct(data));
            try
            {
                return Ok(await fd.FindById(id));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        //[HttpGet("{id}/search")] ///https://localhost:7097/Products/search?name=asdd
        //public IActionResult GetProduvtByName(int id,[FromQuery] string name)
        //{
        //[HttpGet("search")]
        //public async Task<IActionResult> GetProduvtByName([FromQuery] string name)
        //{
        //    var data = (await ps.Search(name)).Select(ProductResponse.FromProduct);
        //    //return Ok(new {RecieveID= id,product= data});
        //    return Ok(data);

        //}

        [HttpPost("[action]")] //[FromBody]-Json [FromForm]-Multipart/form-data
        public async Task<IActionResult> CreateFoodDrink([FromForm] FdRequest data/*,string fdImgId*/ )
        {
            //var FdImg = await context.FdImgs.Include(x => x.FoodDrink).FirstOrDefaultAsync(x => x.FdImgId.Equals(fdImgId));
            //if (FdImg == null) BadRequest();
            try
            {
                return Ok(await fd.Create(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        //public async Task<ActionResult<Product>> AddProduct([FromForm] ProductRequest productRequest)
        //{

        //    (string errorMessage, string imageName) = await ps.UploadImage(productRequest.FormFiles);
        //    if (!string.IsNullOrEmpty(errorMessage)) return BadRequest(errorMessage);

        //    var product = productRequest.Adapt<Product>();
        //    product.ProductImage = imageName;

        //    //product.Image = "";
        //    await ps.Create(product);


        //    //redirect
        //    //return CreatedAtAction(nameof(GetProductById),new { id = 999},product);
        //    return CreatedAtAction(nameof(AddProduct), product);

        //}


        [HttpPut("[action]/")]
        public async Task<IActionResult> UpdateFoodDrink([FromForm] FdUpdate data)
        {
            try
            {
                return Ok(await fd.Update(data));
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }

        //public async Task<object> UpdateProduct(string id, [FromForm] ProductUpdate productUpdate)
        //{


        //    if (id != productUpdate.ProductId) return BadRequest("ไม่พบข้อมูล");
        //    var result = await context.Products.SingleOrDefaultAsync(a => a.ProductId.Equals(productUpdate.ProductId));
        //    //var result = await ps.FindById(id);
        //    //var result = databaseContext.Products.AsNoTracking().FirstOrDefault(x=>x.ProductId.Equals(product.ProductId));
        //    if (result is null) return Constants.Return400("ไม่พบข้อมูล");
        //    //if (result == null) return NotFound();


        //    #region จัดการรูปภาพ
        //    (string errorMessage, string imageName) = await ps.UploadImage(productUpdate.FormFiles);
        //    if (!string.IsNullOrEmpty(errorMessage)) return BadRequest(errorMessage);

        //    if (!string.IsNullOrEmpty(imageName))
        //    {
        //        await ps.DeleteImage(result.ProductImage);
        //        result.ProductImage = imageName;
        //    }
        //    #endregion

        //    productUpdate.Adapt(result);

        //    //result.Name = product.Name;
        //    //result.Price = product.Price;
        //    //result.Stock = product.Stock;

        //    await ps.Update(result);
        //    //return Ok(result);
        //    return Constants.Return200("อัพเดตข้อมูลสำเร็จ");
        //}


        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteFoodDrink(string id)
        {
            try
            {
                object FoodDrink = await fd.DeleteFoodDrink(id);
                object FdImage = await fdImgService.DeleteAll(id);
                return Ok(new{ FoodDrink,FdImage});
            }
            catch (Exception e)
            {
                return BadRequest(Constants.Return400(e.Message));
            }
        }


        //public async Task<ActionResult<Product>> DeleteProduct([FromQuery] string id)
        //{
        //    var data = await ps.FindById1(id);

        //    if (data == null) return Ok("ไม่พบข้อมูล");

        //    await ps.Delete(data);
        //    //await ps.DeleteImage(data);

        //    return NoContent();
        //}





        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(string id)
        //{
        //    try
        //    {
        //        return Ok(await fd.DeleteFoodDrink(id));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(Constants.Return400(e.Message));
        //    }
        //}


    }
}
