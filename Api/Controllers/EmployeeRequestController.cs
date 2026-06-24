using Api.Entities.EmployeeRequests;
using Api.Entities.Employees;
using Api.Repositories.EmployeeRequests;
using Api.Repositories.KycDocuments;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeRequestController : ControllerBase
    {
        private readonly IEmployeeRequestRepository _repository;

        public EmployeeRequestController(IEmployeeRequestRepository repository) => _repository = repository;

        [HttpGet("get-employee-requests")]
        public async Task<IActionResult> GetEmployeeRequests()
        { 
            var employeeRequests = await _repository.GetAllAsync();
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
            return Created($"api/EmployeeRequest/{resultDto.Id}", new { resultDto.Id });
        }
    }
}
