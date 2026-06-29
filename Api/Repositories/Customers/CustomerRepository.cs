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
            CreatedBy = dto.CreatedBy,
        };

        context.Customers.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    public async Task<List<CustomerEntity>> GetAllAsync()
    {
        return await context.Customers.AsNoTracking().ToListAsync();

    }

    public async Task<CustomerEntity?> GetAsync(long id)
    {
        return await context.Customers.Include(c => c.PhoneDetails)
            .Include(c => c.KycDetails)
            .Include(c => c.EmailDetails)
            .Include(c => c.CustomerLoanHistory)
            .Include(c => c.CustomerStatusHistory)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    private static CustomerDto ToDto(CustomerEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        MiddleName = entity.MiddleName,
        LastName = entity.LastName,
        Suffix = entity.Suffix,
        CreatedBy = entity.CreatedBy,
        CreatedDateTime = entity.CreatedDateTime,
        Status = entity.Status,
        Balance = entity.Balance,
    };
}
