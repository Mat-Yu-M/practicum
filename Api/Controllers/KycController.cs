using Api.Entities.AuditLogs;
using Api.Entities.Kycs;
using Api.Repositories.KycDocuments;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KycController : ControllerBase
{
    private readonly IKycRepository _repository;
    private readonly IAuditLogService _auditLog;
    public KycController(IKycRepository repository, IAuditLogService auditLog)
    {
        _repository = repository;
        _auditLog = auditLog;
    }

    [HttpPost("register-customer-documents")]
    public async Task<IActionResult> CreateKyc([FromBody] CreateKycRequest req)
    {
        var customerExists = await _repository.ExistsAsync(req.CustomerId);

        if (!customerExists)
        {
            return NotFound($"Customer with ID {req.CustomerId} does not exist.");
        }

        var addKycDto = new AddKycDto
        {
            CustomerId = req.CustomerId,
            FullName = req.FullName,
            DocumentType = req.DocumentType,
            Country = req.Country,
            ZipCode = req.ZipCode,
            AddressLine = req.AddressLine,
            DocumentImagePath = req.DocumentImagePath,
            SubmittedBy = req.SubmittedBy
        };

        var resultDto = await _repository.AddAsync(addKycDto);

        var response = new AuditLogResponse(AuditLogType.Add, "Add KYC Document", $"Successfully added KYC document for customer {resultDto.CustomerId}.");
        await _auditLog.LogAsync(response);

        return Created($"/api/users/{resultDto.CustomerId}", new { resultDto.CustomerId });
    }

    [HttpGet("get-customer-documents")]
    public async Task<IActionResult> GetKycs()
    {
        var kycs = await _repository.GetAsync();
        return Ok(kycs);

    }
}