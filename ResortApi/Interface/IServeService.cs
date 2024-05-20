using ResortApi.DTOS.Serve;
using ResortApi.Models;


namespace ResortApi.Interface
{
    public interface IServeService
    {
        Task<IEnumerable<Serve>> FindAll();
        Task<Serve> FindById(int id);

        Task<object> Create(ServeRequest data);


        Task<object> Delete(int id);


        //Task<object> Create(AcmdRequest data);
        Task<object> Update(ServeUpdate data);
        //Task Delete(Accommodation acmd);
        //Task<object> Delete(string id);


    }
}
