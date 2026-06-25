using Api.Constants;
using Api.Entities.AuditLogs;
using Api.Entities.Customers;
using Api.Entities.EmployeeRequests;
using Api.Repositories.AuditLogs;
using Api.Repositories.Customers;
using Api.Repositories.EmployeeRequests;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;
    private readonly IAuditLogService _auditLog;
    public CustomerController(ICustomerRepository repository, IAuditLogService auditLog) {
        _repository = repository;
        _auditLog = auditLog;
    }

    [HttpPost("register-customer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest req)
    {
        var customer = new RegisterCustomerDto
        {
            FirstName = req.FirstName,
            MiddleName = req.MiddleName,
            LastName = req.LastName,
            Suffix = req.Suffix,
            DateOfBirth = req.DateOfBirth
            

        };

        var resultDto = await _repository.AddAsync(customer);


        var auditLogDto = new AddAuditLogDto
        {
            Type = AuditLogType.Add,
            Action = "Register Customer",
            Details = $"Successfully registered customer {resultDto.FirstName} {resultDto.LastName} with ID {resultDto.Id}.",
            PerformedAt = DateTime.UtcNow
        };


        await _auditLog.LogAsync(
            AuditLogType.Add,
            "Register Customer",
            $"Successfully registered customer {resultDto.FirstName} {resultDto.LastName} with ID {resultDto.Id}."
        );

        return Created($"api/cus/{resultDto.Id}", new { resultDto.Id });
    }

    [HttpGet("get-customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _repository.GetAllAsync();

        await _auditLog.LogAsync(
            AuditLogType.Fetch,
            "Fetch Customers",
            "Successfully fetched list of customers."
        );

        return Ok(customers);
    }
}