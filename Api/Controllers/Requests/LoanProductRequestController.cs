using Api.Entities.AuditLogs;
using Api.Entities.LoanProductRequests;
using Api.Repositories.LoanProductRequests;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Requests;

[ApiController]
[Route("api/[Controller]")]
public class LoanProductRequestController : ControllerBase
{
    private readonly ILoanProductRequestRepository _repository;
    private readonly IAuditLogService _auditLogService;

    public LoanProductRequestController(ILoanProductRequestRepository repository, IAuditLogService auditLogService)
    {
        _repository = repository;
        _auditLogService = auditLogService;
    }

    [HttpPost("add-loan-product-request")]
    public async Task<IActionResult> AddLoanProductRequest(AddLoanProductRequestRequest request)
    {
        var loanProductRequests = new AddLoanProductRequestDto
        {
            Name = request.Name,
            Description = request.Description,
            LoanCategory = request.LoanCategory,
            InterestRate = request.InterestRate,
            MinimumAmount = request.MinimumAmount,
            MaximumAmount = request.MaximumAmount,
            MinimumTermMonths = request.MinimumTermMonths,
            MaximumTermMonths = request.MaximumTermMonths,
            IsPromotion = request.IsPromotion,
            RequestType = request.RequestType,
            CreatedBy = request.CreatedBy,
            CreatedDateTime = request.CreatedDateTime
        };

        var resultDto = await _repository.AddAsync(loanProductRequests);

        var response = new AuditLogResponse(AuditLogType.Add, "Added Loan Product Request", $"Successfully added Loan Product Request {resultDto.Id}");
        await _auditLogService.LogAsync(response);

        return Created($"api/LoanProductRequest/{resultDto.Id}", new
        {
            resultDto.Id
        });
    }
}

