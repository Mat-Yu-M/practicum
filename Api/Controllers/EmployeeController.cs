using Api.Entities.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {
    private readonly AppDbContext _db;

    public EmployeeController(AppDbContext db) => _db = db;

    [HttpPost("RegisterEmployee")]
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
}

