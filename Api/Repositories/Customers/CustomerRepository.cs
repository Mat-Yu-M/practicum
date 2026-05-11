using Api.Constants;
using Api.Entities;

namespace Api.Repositories.Customers;

public sealed class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public async Task<UserDto> AddAsync(RegisterUserDto dto)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var entity = new UserEntity
        {
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            Email = dto.Email,
            Password = hashedPassword,
            CreatedDateTime = DateTime.UtcNow,
            Status = UserStatus.Unverified
        };

        context.Users.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    private static UserDto ToDto(UserEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        MiddleName = entity.MiddleName,
        LastName = entity.LastName,
        Email = entity.Email,
        CreatedDateTime = entity.CreatedDateTime,
        Status = entity.Status,
    };
}