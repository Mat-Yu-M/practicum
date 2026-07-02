using Api.Constants;
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

    [HttpPost("test-create-employee")]
    public async Task<IActionResult> TestCreateEmployee()
    {
        var firstNames = new[]
        {
        "Adrian", "Bianca", "Carlo", "Danielle", "Ethan",
        "Faith", "Gabriel", "Hannah", "Isaac", "Jasmine",
        "Joshua", "Kevin", "Liam", "Maria", "Nathaniel",
        "Olivia", "Patrick", "Rafael", "Sophia", "Tristan"
    };

        var middleNames = new[]
        {
        "Miguel", "Marie", "Paul", "Anne", "James",
        "Nicole", "Lorenzo", "Sophia", "Daniel", "Mae",
        "Kyle", "Joy", "Patrick", "Angela", "John",
        "Grace", "Vincent", "Dominic", "Claire", "Louise"
    };

        var lastNames = new[]
        {
        "Santos", "Reyes", "Garcia", "Cruz", "Mendoza",
        "Torres", "Navarro", "Aquino", "Villanueva", "Castillo",
        "Flores", "Ramos", "Herrera", "Mercado", "Fernandez",
        "Rosario", "Bautista", "Gonzales", "Morales", "Cabrera"
    };

        var suffixes = new[] { "", "", "", "", "Jr.", "Sr.", "III" };

        var random = new Random();

        for (int x = 0; x < 10; x++)
        {
            var firstName = firstNames[random.Next(firstNames.Length)];
            var middleName = middleNames[random.Next(middleNames.Length)];
            var lastName = lastNames[random.Next(lastNames.Length)];
            var suffix = suffixes[random.Next(suffixes.Length)];
            EmployeeRoles = new List<EmployeeRoles>
{
    EmployeeRoles.EmployeeRoleMaker
},
            var employee = new RegisterEmployeeDto
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Suffix = suffix,
                Email = $"{firstName.ToLower()}.{lastName.ToLower()}@gmail.com",
                Password = "Password123!",
                EmployeeId = $"EMP{random.Next(100000, 999999)}",
                EmployeeRoles = [EmployeeRoles.EmployeeRoleMaker],
                CreatedBy = "Admin",
                CreatedDateTime = DateTime.Now,
                ApprovedBy = "System",
                ApprovedDateTime = DateTime.Now,
            };

            await _repository.AddAsync(employee);

            var response = new AuditLogResponse(
                AuditLogType.Add,
                "Employee Registration",
                $"Employee {employee.FirstName} {employee.LastName} with ID {employee.EmployeeId} registered successfully."
            );

            await _auditLogService.LogAsync(response);
        }

        return Ok();
    }

}


