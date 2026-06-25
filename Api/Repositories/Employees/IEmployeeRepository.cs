using Api.Entities.Employees;

namespace Api.Repositories.Employees;

public interface IEmployeeRepository
{
    Task<EmployeeDto> AddAsync(RegisterEmployeeDto dto);
    Task<EmployeeDto?> GetByEmailAsync(string email);
    Task<List<EmployeeEntity>> GetAllAsync();
}