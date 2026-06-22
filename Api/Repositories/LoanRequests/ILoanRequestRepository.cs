namespace Api.Repositories.LoanRequests
{
    public interface ILoanRequestRepository
    {
        Task<LoanRequestDto> AddAsync(AddLoanRequestDto dto);
    }
}
