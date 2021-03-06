namespace Darwin.Contracts.HealthChecks;

public record HealthCheckResponse
{
    public string Status { get; init; } = string.Empty;
    public IEnumerable<HealthCheck> Checks { get; init; } = new List<HealthCheck>();
    public TimeSpan Duration { get; init; }
}