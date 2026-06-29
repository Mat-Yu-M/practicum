using Api.Entities.CustomerStatusHistories;

namespace Api.Repositories.CustomerStatusHistories;

public sealed class CustomerStatusHistoryRepository(AppDbContext context) : ICustomerStatusHistoryRepository
{
    public async Task<CustomerStatusHistoryDto> AddAsync(AddCustomerStatusHistoryDto dto)
    {
        var customer = await context.Customers.FindAsync(dto.CustomerId)
            ?? throw new KeyNotFoundException($"Customer with ID {dto.CustomerId} not found.");

        var entity = new CustomerStatusHistoryEntity
        {
            Id = 0,
            CustomerId = dto.CustomerId,
            CustomerName = dto.CustomerName,
            BeforeStatus = dto.BeforeStatus,
            AfterStatus = dto.AfterStatus,
            CreatedBy = dto.CreatedBy,
            CreatedDateTime = dto.CreatedDateTime
        };

        customer.Status = dto.AfterStatus;

        context.CustomerStatusHistories.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }
    private static CustomerStatusHistoryDto ToDto(CustomerStatusHistoryEntity entity) => new()
    {
        Id = entity.Id,
        CustomerId = entity.CustomerId,
        CustomerName = entity.CustomerName,
        BeforeStatus = entity.BeforeStatus,
        AfterStatus = entity.AfterStatus,
        CreatedBy = entity.CreatedBy,
        CreatedDateTime = entity.CreatedDateTime,
    };

}

