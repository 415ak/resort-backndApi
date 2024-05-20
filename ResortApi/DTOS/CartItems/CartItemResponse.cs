using ResortApi.Models;
//using ResortApi.DTOS.FoodDrinks;
using ResortApi.Settings;

namespace ResortApi.DTOS.CartItems
{
    public class CartItemResponse
    {
        static public object CartItemProductCateOneImg(CartItem data) => new
        {
            data.Id,
            data.FdId,
            data.Amount,
            data.CreateDate,
            SumAmountPrice = data.FoodDrink.FdPrice * data.Amount,
            FdName = data.FoodDrink.FdName,
            FdCategoryName = data.FoodDrink.FdCategory.Name,
            FdPrice = data.FoodDrink.FdPrice,
            FdImg = data.FoodDrink.FdImgs.Count > 0 
                ? Constants.PathServer + data.FoodDrink.FdImgs.First().FdImgName
                : null,
        };


    }
}