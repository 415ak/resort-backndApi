using ResortApi.DTOS.FoodDrinks;
using ResortApi.Models;

namespace ResortApi.Interface
{
    public interface IFoodDrinkService
    {
        Task<IEnumerable<FoodDrink>> FindAll();
        Task<object> GetFoodDrinks();
        //Task<object> GetProducts(int currentPage, int pageSize, string categoryId, string search);

        Task<FoodDrink> FindById(string id);
        Task<FoodDrink> FindById1(string id);
        Task<object> Create(FdRequest data);
        Task<object> Update(FdUpdate data);
        Task Delete(FoodDrink product);
        Task<object> DeleteFoodDrink(string id);

        Task<IEnumerable<FoodDrink>> Search(string name);
        //Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);
        Task DeleteImage(string imageName);
        
    }
}
