using Api.Entities.Employees;
using Api.Repositories.Employees;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

public sealed class EmployeeRepository(AppDbContext context) : IEmployeeRepository
{
    public async Task<EmployeeDto> AddAsync(RegisterEmployeeDto dto)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        
        var entity = new EmployeeEntity
        {
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            Suffix = dto.Suffix,
            EmployeeId = dto.EmployeeId,
            EmployeeRoles = dto.EmployeeRoles.ToList(),
            Email= dto.Email,
            Password = hashedPassword,
            ApprovedBy = dto.ApprovedBy,
            ApprovedDateTime = dto.ApprovedDateTime,
            CreatedBy = dto.CreatedBy,
            CreatedDateTime = dto.CreatedDateTime
        };

        context.Employees.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    public async Task<EmployeeDto?> GetByEmailAsync(string email)
    {
        var entity = await context.Employees.FirstOrDefaultAsync(e => e.Email == email);
        return entity is null ? null : ToDto(entity);
    }

    private static EmployeeDto ToDto(EmployeeEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        MiddleName = entity.MiddleName,
        LastName = entity.LastName,
        Suffix = entity.Suffix,
        EmployeeId= entity.EmployeeId,
        EmployeeRoles= entity.EmployeeRoles.ToList(),
        Email = entity.Email,
        Password = entity.Password,
        ApprovedBy= entity.ApprovedBy,
        ApprovedDateTime = entity.ApprovedDateTime,
        CreatedBy = entity.CreatedBy,
        CreatedDateTime = entity.CreatedDateTime
    };

}