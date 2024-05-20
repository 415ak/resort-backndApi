using ResortApi.DTOS.Serve;
using ResortApi.Models;

namespace ResortApi.Interface
{
    public interface IServeTypeService
    {
        Task<object> Create(ServeTypeRequest data);

        Task<IEnumerable<ServeType>> GetAll();
    }
}
