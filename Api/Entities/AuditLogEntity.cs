namespace Api.Entities

public sealed class AuditLogEntity
{
    public long Id { get; init; }
    public string Action { get; init; } = null!;
    public string PerformedBy { get; init; } = null!;
    public DateTime PerformedAt { get; init; } = DateTime.UtcNow;
    public string? Details { get; init; }
}
