namespace Api.Repositories.LoanProducts
{
    public interface ILoanProductRepository
    {
        Task<LoanProductDto> AddAsync(AddLoanProductDto dto);
    }
}
