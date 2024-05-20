using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.Serve;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class ServeTypeService : IServeTypeService
    {
        private readonly DatabaseContext context;
        public ServeTypeService(DatabaseContext context)
        {
            this.context = context;
        }
        public async Task<object> Create(ServeTypeRequest data)
        {
            await context.ServiceTypes.AddAsync(new ServeType
            {
                ServeTypeId = Constants.uuid18(),
                Name = data.Name
                //CreatedDate = DateTime.Now,
                //IsUsed = 1
            });
            await context.SaveChangesAsync();
            return data;
        }


        public async Task<IEnumerable<ServeType>> GetAll()
        {
            var show = await context.ServiceTypes.ToListAsync();

            return show;
        }

    }
}
