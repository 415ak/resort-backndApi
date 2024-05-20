

using ResortApi.Settings;

namespace ResortApi.DTOS.ServeCart
{
    public class ServeCartResponse
    {

            static public object CartItemProductCateOneImg(Models.ServeCart data) => new
            {
                data.Id,
                data.ServeId,
                data.Amount,
                data.CreateDate,
                SumAmountPrice = data.Serve.Price * data.Amount,
                Name = data.Serve.Name,
                //FdCategoryName = data.Serve..Name,
                Price = data.Serve.Price,
                Image = data.Serve.ServeImgs.Count > 0
                    ? Constants.PathServer + data.Serve.ServeImgs.First().Image
                    : null,
            };

    }
}
