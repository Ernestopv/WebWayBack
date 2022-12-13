using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using WebWayBack.Models.Validators;

namespace WebWayBack.Models.Extensions
{
    /// <summary>
    /// Provides extension methods for the <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {

        /// <summary>
        /// Adds the models fluent validations into the pipeline.
        /// </summary>
        /// <param name="services">The service collections.</param>
        /// <returns>An instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddModelsFluentValidation(this IServiceCollection services)
        {

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<RequestValidator>();

            return services;
        }
    }
}
