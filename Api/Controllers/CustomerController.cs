using Api.Entities.AuditLogs;
using Api.Entities.Customers;
using Api.Repositories.AuditLogs;
using Api.Repositories.Customers;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;
    private readonly IAuditLogService _auditLog;
    private readonly IDataProtector _protector;

    public CustomerController(ICustomerRepository repository, IAuditLogService auditLog, IDataProtectionProvider provider)
    {
        _repository = repository;
        _auditLog = auditLog;
        _protector = provider.CreateProtector("CustomerIdProtector");
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


        var response = new AuditLogResponse(
            AuditLogType.Add,
            "Register Customer",
            $"Successfully registered customer {resultDto.FirstName} {resultDto.LastName} with ID {resultDto.Id}.");

        await _auditLog.LogAsync(response);

        return Created($"api/cus/{resultDto.Id}", new { resultDto.Id });
    }

    [HttpGet("get-customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _repository.GetAllAsync();

        var response = new AuditLogResponse(
            AuditLogType.Fetch,
            "Fetch Customers",
            "Successfully fetched list of customers.");

        await _auditLog.LogAsync(response);

        return Ok(customers);
    }

    [HttpGet("get-customer")]
    public async Task<IActionResult> GetCustomer(string id)
    {
        long customerId;

        try
        {
            customerId = long.Parse(_protector.Unprotect(id));
        }
        catch
        {
            return BadRequest(new { message = "Invalid customer id." });
        }

        var customer = await _repository.GetAsync(customerId);

        if (customer == null)
            return NotFound(new { message = "Customer Does not Exist" });

        var response = new AuditLogResponse(AuditLogType.Fetch, "Fetched Customer Profile", $"Successfully fetched Customer {customerId}");

        await _auditLog.LogAsync(response);

        var customerResponse = new CustomerResponse(
        _protector.Protect(customer.Id.ToString()),
        customer.FirstName,
        customer.MiddleName,
        customer.Suffix,
        customer.LastName,
        customer.DateOfBirth,
        customer.Balance,
        customer.Status,
        customer.CreatedBy,
        customer.CreatedDateTime
        );

        return Ok(customerResponse);
    }
}