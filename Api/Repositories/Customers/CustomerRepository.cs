using Api.Constants;
using Api.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Customers;

public sealed class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public async Task<CustomerDto> AddAsync(RegisterCustomerDto dto)
    {
        var entity = new CustomerEntity
        {
            FirstName = dto.FirstName,
            MiddleName = dto.MiddleName,
            LastName = dto.LastName,
            Suffix = dto.Suffix,
            DateOfBirth = dto.DateOfBirth,
            CreatedDateTime = DateTime.UtcNow,
            Status = CustomerStatus.Defaulted,
        };

        context.Customers.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    public async Task<List<CustomerEntity>> GetAllAsync()
    {
        return await context.Customers.AsNoTracking().ToListAsync();

    }

    private static CustomerDto ToDto(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        MiddleName = entity.MiddleName,
        LastName = entity.LastName,
        CreatedDateTime = entity.CreatedDateTime,
        Status = entity.Status,
        Balance = entity.Balance,
    };
}