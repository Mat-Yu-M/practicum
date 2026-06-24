using Api.Entities.Employees;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _db;

    public EmployeeController(AppDbContext db) => _db = db;

    [HttpPost("register-employee")]
    public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeRequest req)
    {
        var employee = new EmployeeEntity { 
            
            FirstName = req.FirstName,
            MiddleName = req.MiddleName,
            LastName= req.LastName,
            Suffix = req.Suffix,
            Email = req.Email,
            Password = req.Password,
            EmployeeId = $"{req.FirstName.Substring(0, 1)}{req.LastName.Substring(0, 1)}",
            EmployeeRoles = req.EmployeeRoles,
            CreatedBy = req.CreatedBy,
            CreatedDateTime = req.CreatedDateTime,
            ApprovedBy = req.ApprovedBy,
            ApprovedDateTime = req.ApprovedDateTime,

        };

        _db.Employees.Add(employee);
        await _db.SaveChangesAsync();

        return Created($"/api/employees/{employee.Id}", new { employee.Id });

    }

    [HttpPost("login-employee")]
    [EnableRateLimiting("RegistrationPolicy")]
    public async Task<IActionResult> GetExistingEmployee([FromBody] GetExistingEmployeeRequest req)
    {
        var employee = await _db.Employees.FirstOrDefaultAsync(e => e.Email.ToLower() == req.Email.ToLower());

        if (employee == null)
        {
        return NotFound(new { message = "Account does not exist." });
        }

        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(req.Password, employee.Password);

        if (!isPasswordValid)
        {
        return Unauthorized(new { message = "Exists but Wrong Credentials inputted" });
        }

        return Ok(new
        {
            exists = true,
            message = "Authentication Successful",
            employeeId = employee.Id
        });
        
    }
}

