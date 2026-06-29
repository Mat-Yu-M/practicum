using Api.Entities.AuditLogs;
using Api.Entities.Employees;
using Api.Repositories.Employees;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

namespace Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeRepository _repository;
    private readonly IAuditLogService _auditLogService;
    public EmployeeController(IEmployeeRepository repository, IAuditLogService auditLogService, ILogger<EmployeeController> logger)
    {
        _repository = repository;
        _auditLogService = auditLogService;
        _logger = logger;
    }

    [HttpPost("register-employee")]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeResponse req)
    {
        var employee = new RegisterEmployeeDto
        {

            FirstName = req.FirstName,
            MiddleName = req.MiddleName,
            LastName = req.LastName,
            Suffix = req.Suffix,
            Email = req.Email,
            Password = req.Password,
            EmployeeId = req.EmployeeId,
            EmployeeRoles = req.EmployeeRoles,
            CreatedBy = req.CreatedBy,
            CreatedDateTime = req.CreatedDateTime,
            ApprovedBy = req.ApprovedBy,
            ApprovedDateTime = req.ApprovedDateTime,

        };

        await _repository.AddAsync(employee);

        var response = new AuditLogResponse(
        AuditLogType.Add,
        "Employee Registration",
        $"Employee {employee.FirstName} {employee.LastName} with ID {employee.EmployeeId} registered successfully.");

        await _auditLogService.LogAsync(response
        );

        return Created($"/api/employees/{employee.Email}", new { employee.EmployeeId });

    }

    [HttpPost("login-employee")]
    [EnableRateLimiting("RegistrationPolicy")]
    public async Task<IActionResult> LoginEmployee([FromBody] GetExistingEmployeeRequest req)
    {
        var employee = await _repository.GetByEmailAsync(req.Email);

        if (employee == null)
        {
            return NotFound(new { message = "Account does not exist." });
        }

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(req.Password, employee.Password);

        if (!isPasswordValid)
        {
            return Unauthorized(new { message = "Exists but Wrong Credentials inputted" });
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, employee.Email),
            new Claim("employee_id", employee.EmployeeId)
        };

        foreach (var role in employee.EmployeeRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
        }


        var response = new AuditLogResponse(
            AuditLogType.Log,
            "Employee Login",
            $"Employee {employee.FirstName} {employee.LastName} with ID {employee.EmployeeId} logged in successfully.");

        await _auditLogService.LogAsync(response
        );

        return Ok(new
        {
            exists = true,
            message = "Authentication Successful",
            id = employee.Id,
            employeeId = employee.EmployeeId,
            email = employee.Email,
            firstName = employee.FirstName,
            lastName = employee.LastName,
            employeeRoles = employee.EmployeeRoles,
            createdBy = employee.CreatedBy,
            createdDateTime = employee.CreatedDateTime,
            approvedBy = employee.ApprovedBy,
            approvedDateTime = employee.ApprovedDateTime
        });


    }

    [HttpGet("get-employees")]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await _repository.GetAllAsync();

        var response = new AuditLogResponse(AuditLogType.Fetch, "Employees Fetched", $"Employees Fetched");
        await _auditLogService.LogAsync(response);

        return Ok(employees);
    }

    [HttpGet("get-employee")]
    public async Task<IActionResult> GetEmployee(long id)
    {
        var employee = await _repository.GetAsync(id);

        if (employee == null)
        {
            return NotFound(new { message = "Account does not exist." });

        }

        var response = new AuditLogResponse(
                AuditLogType.Fetch,
                "Employee Fetched",
                $"Employee {employee.EmployeeId} fetched successfully.");

        await _auditLogService.LogAsync(response);

        return Ok(employee);
    }

    [HttpDelete("delete-employee")]

    public async Task<IActionResult> DeleteEmployee([FromQuery] DeleteEmployeeRequest req)
    {
        var employee = await _repository.DeleteAsync(req);


        if (employee == null)
        {
            return NotFound(employee);
        }

        var response = new AuditLogResponse(AuditLogType.Delete, "Deleted Employee", $"Deleted Employee {employee.EmployeeId} Successfully");

        await _auditLogService.LogAsync(response);

        return Ok(employee);
    }
}


