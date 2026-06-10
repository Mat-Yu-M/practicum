using Api.Entities.Employees;
using Api.Repositories.Employees;

public sealed class EmployeeRepository(AppDbContext context) : IEmployeeRepository
{
    public async Task<EmployeeDto> AddAsync(RegisterEmployeeDto dto)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var entity = new EmployeeEntity
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            EmployeeId = dto.EmployeeId,
            EmployeeRoles = dto.EmployeeRoles.ToList(),
            Email= dto.Email,
            Username = dto.Username,
            Password = hashedPassword,
            CreatedBy = dto.CreatedBy,
            CreatedDate = dto.CreatedDateTime
        };

        context.Employees.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    private static EmployeeDto ToDto(EmployeeEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        EmployeeId= entity.EmployeeId,
        EmployeeRoles= entity.EmployeeRoles.ToList(),
        Email = entity.Email,
        Username = entity.Username,
        Password = entity.Password,
        CreatedBy = entity.CreatedBy,
        CreatedDateTime = entity.CreatedDate
    };

}