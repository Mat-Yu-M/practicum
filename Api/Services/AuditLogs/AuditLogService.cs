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

    public async Task LogAsync(AuditLogType type, string action, string details)
    {
        var auditLogDto = new AddAuditLogDto
        {
            Type = type,
            Action = action,
            Details = details,
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