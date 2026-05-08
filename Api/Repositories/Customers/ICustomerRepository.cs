    namespace Api.Customers;

public interface ICustomerRepository
{
    Task<UserDto> AddAsync(RegisterUserDto dto);     
}