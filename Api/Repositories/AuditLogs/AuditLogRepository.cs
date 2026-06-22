using Api.Constants;
using Api.Entities.AuditLogs;
using Api.Entities.Customers;
using Api.Repositories.Customers;

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
            PerformedBy = dto.PerformedBy,
            PerformedAt = dto.PerformedAt,
            Details = dto.Details
        };

        context.AuditLogs.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    private static AuditLogDto ToDto(AuditLogEntity entity) => new()
    {
        Id = entity.Id,
        Type = entity.Type,
        Action = entity.Action,
        PerformedBy = entity.PerformedBy,
        PerformedAt = entity.PerformedAt,
        Details = entity.Details
    };
}