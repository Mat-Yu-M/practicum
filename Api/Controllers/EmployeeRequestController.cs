using Api.Entities.AuditLogs;
using Api.Entities.EmployeeRequests;
using Api.Repositories.EmployeeRequests;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeRequestController : ControllerBase
    {
        private readonly IEmployeeRequestRepository _repository;
        private readonly IAuditLogService _auditLog;

        public EmployeeRequestController(IEmployeeRequestRepository repository, IAuditLogService auditLog)
        {
            _repository = repository;
            _auditLog = auditLog;
        }

        [HttpGet("get-employee-requests")]
        public async Task<IActionResult> GetEmployeeRequests()
        {
            var employeeRequests = await _repository.GetAllAsync();

            await _auditLog.LogAsync(
                AuditLogType.Fetch,
                "Get Employee Requests",
                $"Successfully fetched {employeeRequests.Count} employee requests."
            );

            return Ok(employeeRequests);
        }

        [HttpPost("add-employee-request")]
        public async Task<IActionResult> CreateEmployeeRequest([FromBody] CreateEmployeeRequestRequest req)
        {
            var addEmployeeRequest = new RegisterEmployeeRequestDto
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

            var resultDto = await _repository.AddAsync(addEmployeeRequest);


            await _auditLog.LogAsync(
                AuditLogType.Add,
                "Add Employee Request",
                $"Successfully added employee request for {addEmployeeRequest.FirstName} {addEmployeeRequest.LastName}."
            );

            return Created($"api/EmployeeRequest/{resultDto.Id}", new { resultDto.Id });
        }
    }
}
