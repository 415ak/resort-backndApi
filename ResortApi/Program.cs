using Microsoft.EntityFrameworkCore;
using ResortApi.Installers;
using ResortApi.Models.Data;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
// builder.Configuration.GetConnectionString("DatabaseContext")
// ));

//// Add services to the container.
builder.Services.MyInstallerExtensions(builder);

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors();


app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors(CORSInstaller.MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
