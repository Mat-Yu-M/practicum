using Api.Constants;
using Api.Entities.AuditLogs;
using Api.Entities.LoanRequests;
using Api.Repositories.LoanRequests;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Requests;

[ApiController]
[Route("api/[Controller]")]
public class LoanRequestController : ControllerBase
{
    private readonly ILoanRequestRepository _repository;
    private readonly IAuditLogService _auditLog;

    public LoanRequestController(ILoanRequestRepository repository, IAuditLogService auditLog)
    {
        _repository = repository;
        _auditLog = auditLog;
    }

    [HttpPost("add-loan-request")]
    public async Task<IActionResult> AddLoanRequest(LoanRequestRequest request)
    {


        var loanRequest = new AddLoanRequestDto
        {
            CustomerId = request.CustomerId,
            Name = request.Name,
            LoanProductId = request.LoanProductId,
            LoanName = request.LoanName,
            Status = CommonStatus.Pending,
            InterestRate = request.InterestRate,
            Amount = request.Amount,
            Months = request.Months,
            CreatedBy = request.CreatedBy,
            CreatedDate = request.CreatedDateTime
        };

        var loanRequestResult = await _repository.AddAsync(loanRequest);

        var response = new AuditLogResponse(AuditLogType.Add, "Successfully added Loan Request", $"Added {loanRequestResult.Id}");

        await _auditLog.LogAsync(response);

        return Created($"api/LoanRequest/{loanRequestResult.Id}", new
        {
            loanRequestResult.Id
        });
    }



    [HttpDelete("reject-loan-request")]
    public async Task<IActionResult> RejectLoanRequest(long id)
    {

        await _repository.DeleteAsync(id);

        var response = new AuditLogResponse(AuditLogType.Reject, "Successfully Rejected Loan Request", $"Rejected {id}");

        await _auditLog.LogAsync(response);

        return Ok();

    }

    [HttpGet("get-loan-requests")]
    public async Task<List<LoanRequestEntity>> GetAll()
    {
        var loanRequests = await _repository.GetAllAsync();

        var response = new AuditLogResponse(AuditLogType.Fetch, "Fetched Loan Requests", "Fetched Loan Requests");

        await _auditLog.LogAsync(response);

        return loanRequests;
    }

}

