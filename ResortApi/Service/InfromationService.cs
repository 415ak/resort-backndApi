using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.Informtion;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;

namespace ResortApi.Service
{
    public class InfromationService : IInformationService
    {
        private readonly DatabaseContext context;
        private readonly IUploadFileService uploadFileService;
        public InfromationService(DatabaseContext context, IUploadFileService uploadFileService)
        {
            this.context = context;
            this.uploadFileService = uploadFileService;
        }

        public Task<object> Create(InformationCreate data)
        {
            throw new NotImplementedException();
        }

        public async Task<object> Delete(int id)
        {
            //var show = await context.Information.
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Information>> FindAll()
        {
            var show = await context.Information.ToListAsync();

            return show;
        }
    }
}
