namespace Api.Repositories.Customers;

public interface ICustomerRepository
{
    Task<UserDto> AddAsync(RegisterUserDto dto);     
}