public interface IUserRepository
{
    Task<UserDto> AddAsync(RegisterUserDto dto);
    Task<UserDto?> GetByIdAsync(long id);
}