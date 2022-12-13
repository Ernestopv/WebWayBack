using WebWayBack.ExternalServices.HealthChecks;

namespace WebWayBack.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks().AddCheck<ExternalServiceHealthCheck>("External Service (WayBack Machine)");

            return services;
        }

    }
}
