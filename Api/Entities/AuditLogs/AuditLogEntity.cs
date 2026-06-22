using Api.Entities.CustomerRequests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.AuditLogs;

public sealed class AuditLogEntity
{
    public long Id { get; init; }
    public AuditLogType Type { get; init; }
    public string Action { get; init; } = null!;
    public string PerformedBy { get; init; } = null!;
    public DateTime PerformedAt { get; init; } = DateTime.UtcNow;
    public string? Details { get; init; }
}

public sealed class AuditLogEntityConfiguration : IEntityTypeConfiguration<AuditLogEntity>
{
    public void Configure(EntityTypeBuilder<AuditLogEntity> builder)
    {
        builder.ToTable("audit_log");
        builder.HasKey(al => al.Id);
    }
}
