using ResortApi.Settings;
using ResortApi.Models;

namespace ResortApi.DTOS.FoodDrinks
{
    public class FdResponse
    {
        static public object FoodDrinkCateOneImageForItemCart(FoodDrink data) => new
        {
            data.FdId,
            data.FdName,
            data.FdCategoryId,
            data.FdPrice,
            Name = data.FdCategory.Name,
            FdImgName = data.FdImgs.Count > 0 ? Constants.PathServer + data.FdImgs.First().FdImgName : null,
        };

        static public object FoodDrinkCateImages(FoodDrink data) => new
        {
            data.FdId,
            data.FdName,
            data.FdPrice,
            //data.ProductStock,
            //data.StockSell,
            data.FdDescription,
            //data.Seed,
            //data.level,
            data.DateTime,
            data.FdCategoryId,
            Name = data.FdCategory.Name,
            FdImg = data.FdImgs.Count > 0 ? data.FdImgs.Select(a => new { a.FdImgId, img = Constants.PathServer + a.FdImgName }) : null,
        };

        static public object FoodDrinkCateOneImage(FoodDrink data) => new
        {
            data.FdId,
            data.FdName,
            data.FdPrice,
            //data.ProductStock,
            //data.StockSell,
            data.FdDescription,
            //data.Seed,
            //data.level,
            data.DateTime,
            data.FdCategoryId,
            Name = data.FdCategory.Name,
            FdImg = data.FdImgs.Count > 0 ? Constants.PathServer + data.FdImgs.First().FdImgName : null,
        };
    }
}

