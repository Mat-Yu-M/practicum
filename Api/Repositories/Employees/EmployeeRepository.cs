using Api.Constants;
using Api.Entities.Employees;
using Api.Repositories.Employees;
using Api.Services.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
            Email = dto.Email,
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

    public async Task<List<EmployeeEntity>> GetAllAsync()
    {
        var employees = await context.Employees.AsNoTracking().ToListAsync();

        return employees;
    }
    public async Task<EmployeeEntity?> GetAsync(long id)
    {
        return await context.Employees.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<EmployeeEntity?> DeleteAsync(DeleteEmployeeRequest request)
    {
        var employee = await context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == request.EmployeeId && e.Email == request.Email);

        if (employee == null)
        {
            return null;
        }

        context.Employees.Remove(employee);

        await context.SaveChangesAsync();
        return employee;

    }


    private static EmployeeDto ToDto(EmployeeEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        MiddleName = entity.MiddleName,
        LastName = entity.LastName,
        Suffix = entity.Suffix,
        EmployeeId = entity.EmployeeId,
        EmployeeRoles = entity.EmployeeRoles.ToList(),
        Email = entity.Email,
        Password = entity.Password,
        ApprovedBy = entity.ApprovedBy,
        ApprovedDateTime = entity.ApprovedDateTime,
        CreatedBy = entity.CreatedBy,
        CreatedDateTime = entity.CreatedDateTime
    };


    public async Task<PagedResult<EmployeeDto>> QueryAsync(
    string? searchTerm,
    EmployeeRoles[] employeeRoles,
    string? sortBy,
    bool isAscending,
    int page,
    int pageSize
    )
    {
        IQueryable<EmployeeEntity> query = context.Employees;

        Expression<Func<EmployeeEntity, object>> keySelector = sortBy?.ToLower() switch
        {
            "employeeId" => e => e.EmployeeId,
            "roles" => e => e.EmployeeRoles,
            _ => e => e.Id,
        };

        query = isAscending ? query.OrderBy(keySelector) : query.OrderByDescending(keySelector);

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            searchTerm = searchTerm.Trim().ToLower();
            query = query.Where(e =>
                e.FirstName.ToLower().Contains(searchTerm) ||
                e.LastName.ToLower().Contains(searchTerm) ||
                e.EmployeeId.ToLower().Contains(searchTerm)
            );
        }

        if (employeeRoles != null && employeeRoles.Length > 0)
        {
            query = query.Where(e => e.EmployeeRoles.Any(r => employeeRoles.Contains(r)));
        }

        query = sortBy?.ToLower() switch
        {
            "employeeid" => isAscending ? query.OrderBy(e => e.EmployeeId) : query.OrderByDescending(e => e.EmployeeId),
            _ => isAscending ? query.OrderBy(e => e.Id) : query.OrderByDescending(e => e.Id)
        };

        int totalCount = await query.CountAsync();

        var items = await query
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

        var dtoItems = items.Select(e => ToDto(e)).ToList();

        return new PagedResult<EmployeeDto>
        {
            Items = dtoItems,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };

    }
}

