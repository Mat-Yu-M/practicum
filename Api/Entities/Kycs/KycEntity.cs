using Api.Constants;
using Api.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.Kycs;

public sealed class KycEntity
{
    public long Id { get; init; }
    public long CustomerId { get; set; }
    public required string FullName { get; set; }
    public CustomerEntity? Customer { get; set; }
    public string? DocumentType { get; init; }
    public required string DocumentImagePath { get; init; }
    public required string Country { get; init; }
    public required string ZipCode { get; init; }
    public required string AddressLine { get; init; }
    public CommonStatus Status { get; set; } = CommonStatus.Pending;
    public required string SubmittedBy { get; set; }
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    public string? ReviewedBy { get; set; } = null!;
    public DateTime? ReviewedAt { get; set; } = DateTime.UtcNow;
}

public sealed class KycEntityConfiguration : IEntityTypeConfiguration<KycEntity>
{
    public void Configure(EntityTypeBuilder<KycEntity> builder)
    {
        builder.ToTable("kyc");

        builder.HasKey(k => k.Id);
    }
}