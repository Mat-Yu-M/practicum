namespace Api.Repositories.EmployeeRequests
{
    public interface IEmployeeRequestRepository
    {
        Task<EmployeeRequestDto> AddAsync(RegisterEmployeeRequestDto dto);
    }
}
