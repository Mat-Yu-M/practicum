namespace Api.Repositories.Customers;

public interface IUserRepository
{
    Task<UserDto> AddAsync(RegisterUserDto dto);     
}