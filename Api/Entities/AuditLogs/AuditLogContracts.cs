namespace Api.Entities.AuditLogs;

public record AuditLogResponse
(
    AuditLogType AuditLogType,
    string Action,
    string Details
);


public record AuditLogValueResponse
(
    AuditLogType AuditLogType,
    string? OldValue,
    string? NewValue,
    string Action,
    string Details
);

