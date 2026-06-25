using Api.Entities.AuditLogs;
using Api.Repositories.AuditLogs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuditLogController : ControllerBase
{
    private readonly IAuditLogRepository _repository;

    public AuditLogController(IAuditLogRepository repository) => _repository = repository;

    [HttpPost("add-audit-log")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddAuditLog([FromBody] AddAuditLogDto dto)
    {
        var resultDto = await _repository.AddAsync(dto);
        return Created($"api/auditlog/{resultDto.Id}", new { resultDto.Id });
    }

    [HttpGet("get-audit-logs")]
    public async Task<List<AuditLogEntity>> GetAuditLogs()
    {
        return await _repository.GetAllAsync();
    }
}



