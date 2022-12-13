using Microsoft.Extensions.DependencyInjection;
using WebWayBack.Services.Implementations;
using WebWayBack.Services.Interfaces;

namespace WebWayBack.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the services dependency injection into the pipeline.
        /// </summary>
        /// <param name="services">The service collections.</param>
        /// <returns>An instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddServicesDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<IWebWayBackService, WebWayBackService>();
            return services;
        }
    }
}
