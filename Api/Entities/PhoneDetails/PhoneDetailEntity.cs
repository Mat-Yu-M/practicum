using Api.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.PhoneDetails;

public sealed class PhoneDetailEntity
{
    public long Id { get; set; }
    public long CustomerId { get; init; }
    public required string PhoneNumber { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedDateTime { get; set; }
    public CustomerEntity Customer { get; init; } = null!;
}

public sealed class PhoneDetailTypeConfiguration : IEntityTypeConfiguration<PhoneDetailEntity>
{
    public void Configure(EntityTypeBuilder<PhoneDetailEntity> builder)
    {
        builder.HasIndex(a => new { a.CustomerId, a.PhoneNumber }).IsUnique();
    }
}
