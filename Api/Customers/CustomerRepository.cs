using Api.Constants;
using Api.Customers;
using k8s.KubeConfigModels;
using Microsoft.AspNetCore.Identity;
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
            PasswordHasher = hashedPassword,
            CreatedDateTime = DateTime.UtcNow,
            Status = UserStatus.Active
        };

        context.Users.Add(entity);
        await context.saveChangesAsync();

        return ToDto(entity)
}

}
