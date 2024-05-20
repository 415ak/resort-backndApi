using ResortApi.Models;

namespace ResortApi.Interface
{
    public interface IFdImgService
    {
        Task<object> Delete(Guid id);
        Task<object> DeleteAll(string id);
        Task Create(FdImg FdImgId);
        Task<(string errorMessage, string imageName)> UploadImage(IFormFileCollection formFiles);


    }
}
