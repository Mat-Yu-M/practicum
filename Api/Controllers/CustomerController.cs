using Api.Entities.AuditLogs;
using Api.Entities.CustomerLoanHistories;
using Api.Entities.Customers;
using Api.Entities.CustomerStatusHistories;
using Api.Entities.EmailDetails;
using Api.Entities.Kycs;
using Api.Entities.PhoneDetails;
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
            DateOfBirth = req.DateOfBirth,
            CreatedBy = req.CreatedBy,
            CreatedDateTime = req.CreatedDateTime
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
    public async Task<IActionResult> GetCustomer(long Id)
    {

        var customer = await _repository.GetAsync(Id);

        if (customer == null)
            return NotFound(new { message = "Customer Does not Exist" });

        await _auditLog.LogAsync(new AuditLogResponse(
            AuditLogType.Fetch,
            "Fetched Customer Profile",
            $"Successfully fetched Customer {Id}"
        ));

        return Ok(new CustomerResponse(
            customer.Id,
            customer.FirstName,
            customer.MiddleName,
            customer.Suffix,
            customer.LastName,
            customer.DateOfBirth,
            customer.Balance,
            customer.Status,
            customer.CreatedBy,
            customer.CreatedDateTime,
            customer.EmailDetails.Select(e => new EmailDetailResponse(e.CustomerId, e.Email, e.CreatedBy, e.CreatedDateTime)),
            customer.PhoneDetails.Select(p => new PhoneDetailResponse(p.CustomerId, p.PhoneNumber, p.CreatedBy, p.CreatedDateTime)),
            customer.KycDetails.Select(k => new KycResponse(k.CustomerId, k.FullName, k.Country, k.ZipCode, k.AddressLine
            , k.DocumentType, k.DocumentImagePath, k.SubmittedBy, k.SubmittedAt)),
            customer.CustomerStatusHistory.Select(csh => new CustomerStatusHistoryResponse(csh.CustomerId, csh.CustomerName, csh.BeforeStatus, csh.AfterStatus, csh.CreatedBy, csh.CreatedDateTime)),
            customer.CustomerLoanHistory.Select(clh => new CustomerLoanHistoryResponse(clh.CustomerId, clh.LoanId, clh.LoanAmount, clh.Status, clh.RepaymentScheduleId, clh.DueDate, clh.CreatedBy, clh.CreatedDateTime, clh.ApprovedBy, clh.ApprovedAt))
        ));
    }
}