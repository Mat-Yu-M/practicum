using Api.Entities.EmployeeRequests;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Api.Repositories.EmployeeRequests;
    public sealed class EmployeeRequestRepository(AppDbContext context) : IEmployeeRequestRepository
    {
        public async Task<EmployeeRequestDto> AddAsync(RegisterEmployeeRequestDto dto)
    {
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var entity = new EmployeeRequestEntity
        {
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            Suffix = dto.Suffix,
            EmployeeId = dto.EmployeeId,
            EmployeeRoles = dto.EmployeeRoles.ToList(),
            Email= dto.Email,
            Password = hashedPassword,
            CreatedBy = dto.CreatedBy,
            CreatedDateTime = dto.CreatedDateTime,
            RequestType = dto.RequestType
        };

        context.EmployeeRequests.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    public async Task<List<EmployeeRequestEntity>> GetAllAsync()
    {
        return await context.EmployeeRequests.AsNoTracking().ToListAsync();
    }

    private static EmployeeRequestDto ToDto(EmployeeRequestEntity entity) => new()
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
        CreatedBy = entity.CreatedBy,
        CreatedDateTime = entity.CreatedDateTime,
        RequestType = entity.RequestType
    };
    }

