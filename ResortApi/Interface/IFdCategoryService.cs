using ResortApi.DTOS.FoodDrinks;
using ResortApi.Models;

namespace ResortApi.Interface
{
    public interface IFdCategoryService
    {
        Task<object> Create(FdCategoryRequest data);

        Task<IEnumerable<FdCategory>> GetAll();
        Task<object> Delete(string id);

    }
}
