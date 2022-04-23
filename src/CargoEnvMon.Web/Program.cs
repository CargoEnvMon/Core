using CargoEnvMon.Web.DataLayer;
using CargoEnvMon.Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.UseAutoDependencies(typeof(Program).Assembly);
builder.Services.AddDbContext<CargoEnvMonDbContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllers();

app.MapFallbackToFile("index.html"); ;

app.Run();