using Api.Entities.AuditLogs;
using Api.Repositories.Loans;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class LoanController : ControllerBase
{
    private readonly ILoanRepository _repository;
    private readonly IAuditLogService _auditLog;

    private LoanController(ILoanRepository repository, IAuditLogService auditLog)
    {
        _repository = repository;
        _auditLog = auditLog;
    }

    [HttpGet("get-loans")]
    public async Task<IActionResult> GetLoans()
    {
        var loans = await _repository.GetAllAsync();

        if (!loans.Any())
        {
            return NotFound(new { message = "No Loans Found." });
        }

        var response = new AuditLogResponse(
        AuditLogType.Fetch, "Fetched Loans", $"Fetched Loans Successfully");


        await _auditLog.LogAsync(response);
        return Ok(loans);
    }


}

