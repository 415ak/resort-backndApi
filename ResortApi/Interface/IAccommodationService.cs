using ResortApi.DTOS.Accommodation;
using ResortApi.Models;

namespace ResortApi.Interface
{
    public interface IAccommodationService
    {
        Task<IEnumerable<Accommodation>> FindAll();
        Task<Accommodation> FindById(string id);

        Task<object> Create(AcmdRequest data);
        Task<object> Update(AcmdUpdate data);
        //Task Delete(Accommodation acmd);
        Task<object> Delete(string id);
        Task<object> ChangeStatus(string id);

        Task<object> ChangeStatusDto(AcmdUpdateStatus id);

        //Task Delete(FoodDrink product);

    }
}
