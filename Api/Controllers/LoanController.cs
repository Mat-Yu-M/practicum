using Api.Entities.AuditLogs;
using Api.Entities.Loans;
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

    public LoanController(ILoanRepository repository, IAuditLogService auditLog)
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

    [HttpGet("get-loan")]
    public async Task<IActionResult> GetLoan(long id)
    {
        var loan = await _repository.GetAsync(id);

        if (loan is null)
        {
            return NotFound(new
            { message = "No Loan Exists." });
        }

        var response = new AuditLogResponse(
        AuditLogType.Fetch, "Fetched Loan", $"Fetched Loan {id} Successfully");

        return Ok(loan);

    }


    [HttpPost("add-loan")]
    public async Task<IActionResult> AddLoan([FromBody] AddLoanRequest request)
    {

        var loan = new AddLoanDto
        {
            CustomerId = request.CustomerId,
            Name = request.Name,
            LoanProductId = request.LoanProductId,
            LoanName = request.LoanName,
            Amount = request.Amount,
            InterestRate = request.InterestRate,
            FinalAmount = request.FinalAmount,
            Status = request.Status,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            CreatedBy = request.CreatedBy,
            CreatedDateTime = request.CreatedDateTime,
            ApprovedBy = request.ApprovedBy,
            ApprovedDateTime = request.ApprovedDateTime
        };

        var result = await _repository.AddAsync(loan);

        var response = new AuditLogResponse(AuditLogType.Add, "Successfully Added Loan", $"Added Loan {result.Id}");

        await _auditLog.LogAsync(response);

        return Created($"/api/loans/{result.Id}", new { result.Id });
    }

    [HttpPost("reduce-balance")]
    public async Task<IActionResult> ReduceBalance([FromBody] LoanBalanceRequest request)
    {
        var result = await _repository.ReduceBalanceAsync(request);

        var response = new AuditLogValueResponse(AuditLogType.Update, request.Balance.ToString(), result.FinalAmount.ToString(), "Successfully Reduced Loan Balance", $"Reduced Loan Balance {result.Id}");

        await _auditLog.LogValueAsync(response);

        return Ok(result);
    }

    public async Task<IActionResult> GetCustomerOngoingLoans(long customerId)
    {
        var result = await _repository.GetCustomerLoan(customerId);

        var response = new AuditLogResponse(AuditLogType.Fetch, "Successfully Fetched Customer's Ongoing Loans", $" Fetched Loan {result}");

        await _auditLog.LogAsync(response);

        return Ok(result);
    }
}
