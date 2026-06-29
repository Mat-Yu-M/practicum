using Api.Entities.AuditLogs;

namespace Api.Repositories.AuditLogs;

public sealed class AuditLogRepository(AppDbContext context) : IAuditLogRepository
{
    public async Task<AuditLogDto> AddAsync(AddAuditLogDto dto)
    {
        var entity = new AuditLogEntity
        {
            Id = dto.Id,
            Type = dto.Type,
            Action = dto.Action,
            OldValue = dto.OldValue,
            NewValue = dto.NewValue,
            PerformedBy = dto.PerformedBy,
            PerformedAt = dto.PerformedAt,
            Details = dto.Details
        };

        context.AuditLogs.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    public async Task<List<AuditLogEntity>> GetAllAsync()
    {
        var auditLogs = context.AuditLogs.OrderByDescending(a => a.PerformedAt).ToList();

        return auditLogs;
    }

    private static AuditLogDto ToDto(AuditLogEntity entity) => new()
    {
        Id = entity.Id,
        Type = entity.Type,
        Action = entity.Action,
        OldValue = entity.OldValue,
        NewValue = entity.NewValue,
        PerformedBy = entity.PerformedBy,
        PerformedAt = entity.PerformedAt,
        Details = entity.Details
    };
}