namespace Api.Entities.AuditLogs;

public record AuditLogResponse
(
    AuditLogType AuditLogType,
    string Action,
    string Details,
    string PerformedBy,
    DateTime PerformedAt
);


public record AuditLogValueResponse
(
    AuditLogType AuditLogType,
    string? OldValue,
    string? NewValue,
    string Action,
    string Details,
    string PerformedBy,
    DateTime PerformedAt
);

