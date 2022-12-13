using WebWayBack.Api.Extensions;
using WebWayBack.ExternalServices.Extensions;
using WebWayBack.Filters.Filters;
using WebWayBack.Infrastructure.Settings;
using WebWayBack.Models.Extensions;
using WebWayBack.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.Get<AppSettings>();



// Add services to the container.

var services = builder.Services;

services.AddSingleton(appSettings);
services.AddModelsFluentValidation();
services.AddControllers(options =>
{
    options.Filters.Add<UnhandledExceptionFilter>();
});
services.AddServicesDependencyInjection();
services.AddExternalServicesDependencyInjection();
services.AddApiHealthChecks();

services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
app.UseRouting();

app.UseApiHealthChecks();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
