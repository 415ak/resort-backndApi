using ResortApi.Settings;
using ResortApi.Models;

namespace ResortApi.DTOS.ServeOrderItems
{
    public class ServeOrderItemResponse
    {
        static public object OrderItemsProduct(ServeOrderItem data) => new
        {
            ServeName = data.Serve.Name,
            ServePrice = data.Serve.Price,
            data.Amount,
            SumAmountPrice = data.Amount * data.Serve.Price
        };

        static public object OrderItemsProductOneImg(ServeOrderItem data) => new
        {
            data.Id,
            data.Amount,
            SumAmountPrice = data.Amount * data.Serve.Price,
            data.ServeId,
            ProductName = data.Serve.Name,
            ProductPrice = data.Serve.Price,
            ProductImage = data.Serve.ServeImgs.Count > 0
                ? Constants.PathServer + data.Serve.ServeImgs.First().Image
                : null,
        };

        static public object OrderItemsProductCateOneImg(ServeOrderItem data) => new
        {
            data.Id,
            data.Amount,
            SumAmountPrice = data.Amount * data.Serve.Price,
            data.ServeId,
            //CategoryName = data.Serve.FdCategory.Name,
            ServeName = data.Serve.Name,
            ProductPrice = data.Serve.Price,
            ProductImage = data.Serve.ServeImgs.Count > 0
                ? Constants.PathServer + data.Serve.ServeImgs.First().Image
                : null,
        };
    }
}
