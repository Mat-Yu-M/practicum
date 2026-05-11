using Api.Repositories.Employees;

namespace Api.Repositories.Employees;

public interface IEmployeeRepository
{
    Task<EmployeeDto> AddAsync(RegisterEmployeeDto dto);
}