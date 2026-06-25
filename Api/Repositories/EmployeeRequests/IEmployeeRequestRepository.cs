using Api.Entities.EmployeeRequests;

namespace Api.Repositories.EmployeeRequests
{
    public interface IEmployeeRequestRepository
    {
        Task<EmployeeRequestDto> AddAsync(RegisterEmployeeRequestDto dto);
        Task<List<EmployeeRequestEntity>> GetAllAsync();
        Task<EmployeeRequestEntity?> DeleteAsync(long Id);
    }
}
