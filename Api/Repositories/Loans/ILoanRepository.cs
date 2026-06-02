namespace Api.Repositories.Loans
{
    public interface ILoanRepository
    {
        Task<LoanDto> AddAsync(AddLoanDto dto);
    }
}
