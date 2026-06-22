namespace Api.Repositories.AuditLogs
{
    public interface IAuditLogRepository
    {
        Task<AuditLogDto> AddAsync(AddAuditLogDto dto);
    }
}
