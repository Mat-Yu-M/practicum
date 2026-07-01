using Api.Entities.LoanRequests;

namespace Api.Repositories.LoanRequests
{
    public interface ILoanRequestRepository
    {
        Task<LoanRequestDto> AddAsync(AddLoanRequestDto dto);
        Task<LoanRequestEntity?> DeleteAsync(long id);
    }
}
