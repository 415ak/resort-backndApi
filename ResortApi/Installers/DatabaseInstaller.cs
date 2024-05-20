using Microsoft.EntityFrameworkCore;
using ResortApi.Models.Data;

namespace ResortApi.Installers
{
    public class DatabaseInstaller : IInstallers
    {
        public void InstallServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
             builder.Configuration.GetConnectionString("DatabaseContext")
             ));
        }
    }
}
