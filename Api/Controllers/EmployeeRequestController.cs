using Api.Entities.EmployeeRequests;
using Api.Entities.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeRequestController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EmployeeRequestController(AppDbContext db) => _db = db;

        [HttpPost("add-employee-request")]
        public async Task<IActionResult> CreateEmployeeRequest([FromBody] CreateEmployeeRequest req)
        {
            var employeeRequest = new EmployeeRequestEntity
            {
                FirstName = req.FirstName,
                MiddleName = req.MiddleName,
                LastName = req.LastName,
                Suffix = req.Suffix,
                Email = req.Email,
                Password = req.Password,
                EmployeeId = req.EmployeeId,
                EmployeeRoles = req.EmployeeRoles,
                RequestType = req.RequestType,
                CreatedBy = req.CreatedBy,
                CreatedDateTime = req.CreatedDateTime
            };
            _db.EmployeeRequests.Add(employeeRequest);
            await _db.SaveChangesAsync();
            return Created($"/api/employee-requests/{employeeRequest.Id}", new { employeeRequest.Id });
        }
    }
}
