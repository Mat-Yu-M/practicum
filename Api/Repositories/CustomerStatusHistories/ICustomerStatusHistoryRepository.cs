namespace Api.Repositories.CustomerStatusHistories
{
    public interface ICustomerStatusHistoryRepository
    {
        Task<CustomerStatusHistoryDto> AddAsync(AddCustomerStatusHistoryDto dto);
    }
}
