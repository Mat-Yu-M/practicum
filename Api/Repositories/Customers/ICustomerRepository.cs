using Api.Entities.Customers;

namespace Api.Repositories.Customers;

public interface ICustomerRepository
{
    Task<CustomerDto> AddAsync(RegisterCustomerDto dto);
    Task<List<CustomerEntity>> GetAllAsync();
}