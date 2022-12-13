namespace WebWayBack.Models.HealthChecks
{
    public class HealthCheckDetail
    {
        public string Component { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string Status { get; set; } = default!;
    }
}
