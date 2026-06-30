using Api.Entities.AuditLogs;
using Api.Repositories.EmailDetails;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class EmailDetailController : ControllerBase
{
    private readonly IEmailDetailRepository _repository;
    private readonly IAuditLogService _auditLogs;
    public EmailDetailController(IEmailDetailRepository repository, IAuditLogService auditLogs)
    {
        _repository = repository;
        _auditLogs = auditLogs;
    }

    [HttpPost("add-email")]
    public async Task<IActionResult> AddAsync(EmailDetailDto dto)
    {
        var emailDetails = new AddEmailDetailDto
        {
            CustomerId = dto.CustomerId,
            Email = dto.Email,
            CreatedBy = dto.CreatedBy,
            CreatedDateTime = dto.CreatedDateTime
        };

        await _repository.AddAsync(emailDetails);

        var response = new AuditLogValueResponse(AuditLogType.Add, null, emailDetails.Email, "Added Email", $"Successfully added Email to {emailDetails.CustomerId}");

        await _auditLogs.LogValueAsync(response);

        return Created($"api/emailDetails/{emailDetails.CustomerId}", new { emailDetails.CustomerId });
    }
}

