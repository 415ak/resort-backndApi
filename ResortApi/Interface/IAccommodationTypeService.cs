using ResortApi.DTOS.Accommodation;
using ResortApi.Models;

namespace ResortApi.Interface
{
    public interface IAccommodationTypeService
    {
        Task<object> Create(AcmdTypeRequest data);

        Task<IEnumerable<AccommodationType>> GetAll();


    }
}
