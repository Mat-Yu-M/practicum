using Api.Constants;
using Api.Entities;
using Api.Repositories.Customers;
using Api.Repositories.Employees;

public sealed class EmployeeRepository(AppDbContext context) : IEmployeeRepository
{
    public async Task<EmployeeDto> AddAsync(RegisterEmployeeDto dto)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var entity = new EmployeeEntity
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHasher = hashedPassword,
            CreatedDateTime = DateTime.UtcNow,
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
        CreatedDateTime = entity.CreatedDateTime
    };
}