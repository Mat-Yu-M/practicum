using Api.Entities.AuditLogs;

namespace Api.Services.AuditLogs
{
    public interface IAuditLogService
    {
        Task LogAsync(AuditLogResponse response);

        Task LogValueAsync(AuditLogValueResponse response);
    }
}
