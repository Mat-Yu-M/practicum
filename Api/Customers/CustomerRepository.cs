using k8s.KubeConfigModels;
using Microsoft.AspNetCore.Identity;

public async Task<UserDto> AddAsync(RegisterUserDto dto)
{
    string hashedPassword = _passwordHasher.HashPassword(dto.Password);

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

    context.users.add(entity);
    await context.saveChangesAsync();

    return ToDto(entity)
}
