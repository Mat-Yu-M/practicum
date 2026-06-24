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
            EmployeeId = $"{req.FirstName.Substring(0, 1)}{req.LastName.Substring(0, 1)}",
            EmployeeRoles = req.EmployeeRoles,
            Password = req.Password,
            Email = req.Email,
            ApprovedBy = req.ApprovedBy,
            ApprovedDate = req.ApprovedDate,
            CreatedBy = req.CreatedBy,
            CreatedDate = req.CreatedDate,
        
        };

        _db.Employees.AddAsync(employee);
        await _db.SaveChangesAsync();

        return Created($"/api/employees/{employee.Id}", new { employee.Id });

    }
}

