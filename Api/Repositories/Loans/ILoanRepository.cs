using Api.Entities.Loans;

namespace Api.Repositories.Loans
{
    public interface ILoanRepository
    {
        Task<LoanDto> AddAsync(AddLoanDto dto);
        Task<List<LoanEntity>> GetAllAsync();
        Task<LoanEntity?> GetAsync(long id);
    }
}
