using Api.Entities.AuditLogs;

namespace Api.Repositories.AuditLogs;

    public sealed record AuditLogDto
    {
        public long Id { get; init; }
        public AuditLogType Type { get; init; }
        public string Action { get; init; } = null!; 
        public string OldValue { get; init; }
        public string NewValue { get; init; }
        public string PerformedBy { get; init; } = null!;
        public DateTime PerformedAt { get; init; } = DateTime.UtcNow;
        public string? Details { get; init; }
    }

    public sealed record AddAuditLogDto
    {
    public long Id { get; init; }
    public AuditLogType Type { get; init; }
    public string Action { get; init; } = null!;
    public string OldValue { get; init; }
    public string NewValue { get; init; }
    public string PerformedBy { get; init; } = null!;
    public DateTime PerformedAt { get; init; } = DateTime.UtcNow;
    public string? Details { get; init; }
}