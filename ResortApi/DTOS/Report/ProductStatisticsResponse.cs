using ResortApi.DTOS.FoodDrinks;
using ResortApi.DTOS.Accommodation;
using ResortApi.Models;
using ResortApi.Settings;

namespace ResortApi.DTOS.Report
{
    public class ProductStatisticsResponse
    {
        public string? ID { get; set; }
        public int? id { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        public string Detail { get; set; }
        public string CategoryName { get; set; }

        //public string CommunityGroupName { get; set; }

        //public string LevelRarityName { get; set; }

        //public int CategoryProductID { get; set; }

        //public int CommunityGroupID { get; set; }

        //public int LevelRarityID { get; set; }
        //public string TextHistory { get; set; }

        public Models.Accommodation Accmd { get; set; }
        public Models.Serve Sereve { get; set; }


        public FoodDrink Product { get; set; }
        public double? NumPercen { get; set; }
        public double? Amount { get; set; }

        static public ProductStatisticsResponse FromProductStatistics(ProductStatisticsDTO product)
        {
            // return ตัวมันเอง ProductStatisticsDTO
            return new ProductStatisticsResponse
            {
                ID = product.Product.FdId,
                Name = product.Product.FdName,
                //Image = !string.IsNullOrEmpty(product.Product.FdImgs) ? ServerURLcs.URLServer + "images/" + product.Product.Image : "",
                Image = product.Product.FdImgs.Count > 0 ? Constants.PathServer + product.Product.FdImgs.First().FdImgName : null,
                //Stock = product.Product.Stock, 
                Price = product.Product.FdPrice,
                Detail = product.Product.FdDescription,
                CategoryName = product.Product.FdCategory.Name,
                //CommunityGroupName = product.Product.CommunityGroup.CommunityGroupName, 
                //LevelRarityName = product.Product.LevelRarity.LevelRarityName,
                Amount = product.Amount,
                NumPercen = product.NumPercen,

            };

        }

        internal static object FromProductStatistics(SalesStatisticsDTO result)
        {
            throw new NotImplementedException();
        }

        static public ProductStatisticsResponse FromAccmdStatistics(AccmdStatisticsDTO product)
        {
            // return ตัวมันเอง ProductStatisticsDTO
            return new ProductStatisticsResponse
            {
                ID = product.Accmd.AccommodationId,
                Name = product.Accmd.Name,
                //Image = !string.IsNullOrEmpty(product.Product.FdImgs) ? ServerURLcs.URLServer + "images/" + product.Product.Image : "",
                Image = product.Accmd.AccommodationImgs.Count > 0 ? Constants.PathServer + product.Accmd.AccommodationImgs.First().Image : null,
                //Stock = product.Product.Stock, 
                Price = product.Accmd.Price,
                Detail = product.Accmd.Detail,
                CategoryName = product.Accmd.AccommodationType.Name,
                //CommunityGroupName = product.Product.CommunityGroup.CommunityGroupName, 
                //LevelRarityName = product.Product.LevelRarity.LevelRarityName,
                Amount = product.Amount,
                NumPercen = product.NumPercen,

            };

        }

        static public ProductStatisticsResponse FromServeStatistics(ServeStatisticsDTO product)
        {
            // return ตัวมันเอง ProductStatisticsDTO
            return new ProductStatisticsResponse
            {
                id = product.Serve.ServeId,
                Name = product.Serve.Name,
                //Image = !string.IsNullOrEmpty(product.Product.FdImgs) ? ServerURLcs.URLServer + "images/" + product.Product.Image : "",
                Image = product.Serve.ServeImgs.Count > 0 ? Constants.PathServer + product.Serve.ServeImgs.First().Image : null,
                //Stock = product.Product.Stock, 
                Price = product.Serve.Price,
                Detail = product.Serve.Detail,
                //CategoryName = product.Serve.FdCategory.Name,
                //CommunityGroupName = product.Product.CommunityGroup.CommunityGroupName, 
                //LevelRarityName = product.Product.LevelRarity.LevelRarityName,
                Amount = product.Amount,
                NumPercen = product.NumPercen,

            };

        }




    }
}


//{
//    "msg": "OK",
//  "data": [
//    {
//        "product": {
//            "id": 5,
//        "name": "test03",
//        "price": 111,
//        "stock": 47,
//        "detail": "test",
//        "image": "02419195-aadc-4e10-abcc-f468c5b00364.png",
//        "categoryProductID": 2,
//        "categoryProduct": null,
//        "communityGroupID": 1,
//        "communityGroup": null,
//        "levelRarityID": 1,
//        "levelRarity": null
//        },
//      "numPercen": 100,
//      "amount": 3
//    }
//  ]
//}