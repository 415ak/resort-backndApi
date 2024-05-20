using ResortApi.Settings;
using ResortApi.Models;

namespace ResortApi.DTOS.OrderItems
{
    public class OrderItemResponse
    {
        static public object OrderItemsProduct(OrderItem data) => new
        {
            ProductName = data.FoodDrink.FdName,
            ProductPrice = data.FoodDrink.FdPrice,
            data.Amount,
            SumAmountPrice = data.Amount * data.FoodDrink.FdPrice 
        };

        static public object OrderItemsProductOneImg(OrderItem data) => new
        {
            data.Id,
            data.Amount,
            SumAmountPrice = data.Amount * data.FoodDrink.FdPrice,
            data.FdId,
            ProductName = data.FoodDrink.FdName,
            ProductPrice = data.FoodDrink.FdPrice,
            ProductImage = data.FoodDrink.FdImgs.Count > 0
                ? Constants.PathServer + data.FoodDrink.FdImgs.First().FdImgName
                : null,
        };

        static public object OrderItemsProductCateOneImg(OrderItem data) => new
        {
            data.Id,
            data.Amount,
            SumAmountPrice = data.Amount * data.FoodDrink.FdPrice,
            data.FdId,
            CategoryName = data.FoodDrink.FdCategory.Name,
            ProductName = data.FoodDrink.FdName,
            ProductPrice = data.FoodDrink.FdPrice,
            ProductImage = data.FoodDrink.FdImgs.Count > 0
                ? Constants.PathServer + data.FoodDrink.FdImgs.First().FdImgName
                : null,
        };
    }
}
