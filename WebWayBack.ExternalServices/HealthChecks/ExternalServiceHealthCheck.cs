using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using WebWayBack.ExternalServices.Interfaces;

namespace WebWayBack.ExternalServices.HealthChecks
{
    public class ExternalServiceHealthCheck : IHealthCheck
    {
        private readonly ILogger<ExternalServiceHealthCheck> _logger;

        private readonly IExternalService _externalService;
        public ExternalServiceHealthCheck(IExternalService externalService, ILogger<ExternalServiceHealthCheck> logger)
        {
            _logger = logger;
            _externalService = externalService;

        }
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new())
        {
            try
            {
                if (await _externalService.CheckExternalServiceConnectionAsync(cancellationToken))
                {
                    _logger.LogInformation("External Service Healthy");
                    return HealthCheckResult.Healthy();
                }
                _logger.LogError("External Service UnHealthy");
                return HealthCheckResult.Unhealthy();
            }
            catch (Exception ex)
            {
                return new HealthCheckResult(
                    context.Registration.FailureStatus,
                    "Failed health check!",
                    ex);
            }
        }
    }
}
