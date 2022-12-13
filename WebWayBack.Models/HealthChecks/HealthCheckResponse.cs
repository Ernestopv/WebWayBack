namespace WebWayBack.Models.HealthChecks
{
    public class HealthCheckResponse
    {
        public IEnumerable<HealthCheckDetail> Details { get; set; } = default!;

        public TimeSpan Duration { get; set; }

        public string Status { get; set; } = default!;
    }
}
