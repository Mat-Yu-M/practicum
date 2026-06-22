using Api.Constants;
using Api.Entities.Customers;

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
            CreatedDateTime = DateTime.UtcNow,
            Status = CustomerStatus.Defaulted,
            Balance = dto.Balance,
        };

        context.Customers.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
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