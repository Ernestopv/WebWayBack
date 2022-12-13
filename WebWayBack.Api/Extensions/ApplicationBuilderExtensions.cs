using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using WebWayBack.Models.HealthChecks;

namespace WebWayBack.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApiHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = WriteHealthCheckResponseAsync
            });

            return app;
        }

        private static async Task WriteHealthCheckResponseAsync(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = "application/json";

            var response = new HealthCheckResponse
            {
                Status = report.Status.ToString(),
                Details = report.Entries.Select(x => new HealthCheckDetail
                {
                    Component = x.Key,
                    Status = x.Value.Status.ToString(),
                    Description = x.Value.Description ?? string.Empty
                }),
                Duration = report.TotalDuration
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
    }
}
