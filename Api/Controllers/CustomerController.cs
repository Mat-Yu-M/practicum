using Api.Constants;
using Api.Entities.Customers;
using Api.Entities.EmployeeRequests;
using Api.Repositories.Customers;
using Api.Repositories.EmployeeRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _repository;

    public CustomerController(ICustomerRepository repository) => _repository = repository;

    [HttpPost("register-customer")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest req)
    {
        var addEmployeeRequest = new RegisterCustomerDto
        {
            FirstName = req.FirstName,
            MiddleName = req.MiddleName,
            LastName = req.LastName,
            Suffix = req.Suffix,
            DateOfBirth = req.DateOfBirth
            

        };

        var resultDto = await _repository.AddAsync(addEmployeeRequest);
        return Created($"api/cus/{resultDto.Id}", new { resultDto.Id });
    }

    [HttpGet("get-customers")]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _repository.GetAllAsync();
        return Ok(customers);
    }
}