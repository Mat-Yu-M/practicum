using Api.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Api.Entities.PhoneDetails;
public sealed class PhoneDetailEntity
{
    public long Id { get; set; }
    public required long CustomerId { get; init; }
    public required string? PhoneNumber { get; set; }
    public required string? CountryCode { get; set; }
    public required string? AreaCode { get; set; }
    public required string? ExtensionNumber { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedDateTime { get; set; }
    public required string? ModifiedBy { get; set; }
    public required DateTime? ModifiedDateTime { get; set; }
    public required CustomerEntity Customer { get; init; } = null!;
}

public sealed class PhoneDetailTypeConfiguration : IEntityTypeConfiguration<PhoneDetailEntity>
{
    public void Configure(EntityTypeBuilder<PhoneDetailEntity> builder)
    {
        builder.HasIndex(a => new { a.CustomerId, a.PhoneNumber }).IsUnique();
    }
}
