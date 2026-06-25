using Api.Entities.AuditLogs;

namespace Api.Repositories.AuditLogs
{
    public interface IAuditLogRepository
    {
        Task<AuditLogDto> AddAsync(AddAuditLogDto dto);
        Task<List<AuditLogEntity>> GetAllAsync();
    }
}
