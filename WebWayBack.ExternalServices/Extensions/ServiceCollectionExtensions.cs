using Microsoft.Extensions.DependencyInjection;
using WebWayBack.ExternalServices.Implementations;
using WebWayBack.ExternalServices.Interfaces;

namespace WebWayBack.ExternalServices.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the services dependency injection into the pipeline.
        /// </summary>
        /// <param name="services">The service collections.</param>
        /// <returns>An instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddExternalServicesDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IExternalService, ExternalService>();

            return services;
        }
    }
}
