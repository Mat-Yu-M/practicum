using Api.Entities.AuditLogs;
using Api.Entities.PhoneDetails;
using Api.Repositories.PhoneDetails;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PhoneDetailController : ControllerBase
{
    private readonly IPhoneDetailRepository _repository;
    private readonly IAuditLogService _auditLogs;

    public PhoneDetailController(IPhoneDetailRepository repository, IAuditLogService auditLogs)
    {
        _repository = repository;
        _auditLogs = auditLogs;
    }

    [HttpPost("add-phone-details")]
    public async Task<IActionResult> AddPhoneDetail([FromBody] PhoneDetailRequest request)
    {
        var phoneDetails = new AddPhoneDetailDto
        {
            CustomerId = request.CustomerId,
            PhoneNumber = request.PhoneNumber,
            CreatedBy = request.CreatedBy,
            CreatedDateTime = request.CreatedDateTime,
        };

        await _repository.AddAsync(phoneDetails);

        var response = new AuditLogValueResponse(AuditLogType.Add, null, request.PhoneNumber, "Added Phone Detail", $"Successfully Added Phone number to {request.CustomerId}");

        await _auditLogs.LogValueAsync(response);

        return Created($"api/phoneDetails/{phoneDetails.CustomerId}", new { phoneDetails.CustomerId });

    }
}

