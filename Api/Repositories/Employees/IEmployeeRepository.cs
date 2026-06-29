using Api.Constants;
using Api.Entities.Employees;
using Api.Services.Results;

namespace Api.Repositories.Employees;

public interface IEmployeeRepository
{
    Task<EmployeeDto> AddAsync(RegisterEmployeeDto dto);
    Task<EmployeeDto?> GetByEmailAsync(string email);
    Task<List<EmployeeEntity>> GetAllAsync();
    Task<EmployeeEntity?> GetAsync(long id);
    Task<EmployeeEntity?> DeleteAsync(DeleteEmployeeRequest request);
    Task<PagedResult<EmployeeDto>> QueryAsync(
    string? searchTerm,
    EmployeeRoles[] employeeRoles,
    string? sortBy,
    bool isAscending,
    int page,
    int pageSize
    );
}