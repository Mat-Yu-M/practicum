using Api.Entities.AuditLogs;
using Api.Repositories.AuditLogs;
using System.Security.Claims;

namespace Api.Services.AuditLogs;

public class AuditLogService : IAuditLogService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogService(IHttpContextAccessor httpContextAccessor, IAuditLogRepository auditLogRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _auditLogRepository = auditLogRepository;
    }

    public async Task LogAsync(AuditLogResponse response)
    {
        var auditLogDto = new AddAuditLogDto
        {
            Type = response.AuditLogType,
            Action = response.Action,
            Details = response.Details,
            PerformedBy = GetCurrentUser(),
            PerformedAt = DateTime.UtcNow
        };
        await _auditLogRepository.AddAsync(auditLogDto);
    }
    public async Task LogValueAsync(AuditLogValueResponse response)
    {
        var auditLogDto = new AddAuditLogDto
        {
            Type = response.AuditLogType,
            OldValue = response.OldValue,
            NewValue = response.NewValue,
            Action = response.Action,
            Details = response.Details,
            PerformedBy = GetCurrentUser(),
            PerformedAt = DateTime.UtcNow
        };
        await _auditLogRepository.AddAsync(auditLogDto);
    }
    public string GetCurrentUser()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "Admin";
    }
}