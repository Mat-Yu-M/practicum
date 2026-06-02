namespace Api.Repositories.Loans
{
    public interface ILoanRepository
    {
        Task Task<LoanDto> AddAsync(AddLoanDto dto)
    }
}
