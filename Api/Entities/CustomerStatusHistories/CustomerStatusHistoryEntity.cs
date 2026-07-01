using Api.Constants;
using Api.Entities.Customers;
using Microsoft.EntityFrameworkCore;

namespace Api.Entities.CustomerStatusHistories
{
    public sealed class CustomerStatusHistoryEntity
    {
        public long Id { get; init; }
        public required long CustomerId { get; init; }
        public required string CustomerName { get; init; }
        public required CustomerStatus BeforeStatus { get; init; }
        public required CustomerStatus AfterStatus { get; init; }
        public required string CreatedBy { get; init; }
        public required DateTime CreatedDateTime { get; init; }
        public CustomerEntity Customer { get; init; } = null!;

    }

    public sealed class CustomerStatusHistoryEntityConfiguration : IEntityTypeConfiguration<CustomerStatusHistoryEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CustomerStatusHistoryEntity> builder)
        {
            builder.ToTable("customer_status_histories");

            builder.HasKey(c => c.Id);

        }
    }

}