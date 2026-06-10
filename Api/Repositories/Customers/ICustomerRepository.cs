namespace Api.Repositories.Customers;

public interface ICustomerRepository
{
    Task<CustomerDto> AddAsync(RegisterCustomerDto dto);     
}