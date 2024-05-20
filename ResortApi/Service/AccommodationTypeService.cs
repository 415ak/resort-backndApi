using Microsoft.EntityFrameworkCore;
using ResortApi.DTOS.Accommodation;
using ResortApi.Interface;
using ResortApi.Models;
using ResortApi.Models.Data;
using ResortApi.Settings;

namespace ResortApi.Service
{
    public class AccommodationTypeService : IAccommodationTypeService
    {
        private readonly DatabaseContext context;
        public AccommodationTypeService(DatabaseContext context)
        {
            this.context = context;
        }
        public async Task<object> Create(AcmdTypeRequest data)
        {
            await context.AccommodationTypes.AddAsync(new AccommodationType
            {
                AccommodationTypeId = Constants.uuid18(),
                Name = data.Name,
                //CreatedDate = DateTime.Now,
                IsUsed = 1
            });
            await context.SaveChangesAsync();
            return data;
        }


        public async Task<IEnumerable<AccommodationType>> GetAll()
        {
            var show = await context.AccommodationTypes.ToListAsync();

            return show;
        }

    }

}
