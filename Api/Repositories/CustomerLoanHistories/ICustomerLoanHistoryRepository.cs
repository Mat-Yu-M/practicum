namespace Api.Repositories.CustomerLoanHistories
{
    public interface ICustomerLoanHistoryRepository
    {
        Task<CustomerLoanHistoryDto> AddAsync(AddCustomerLoanHistoryDto dto);
    }
}
