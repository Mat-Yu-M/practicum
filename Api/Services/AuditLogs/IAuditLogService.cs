using Api.Entities.AuditLogs;

namespace Api.Services.AuditLogs
{
    public interface IAuditLogService
    {
        Task LogAsync(AuditLogType type, string action, string details);

    }
}
