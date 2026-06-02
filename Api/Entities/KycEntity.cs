using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities;

public sealed class KycEntity
{
    public long Id { get; init; }
    public long UserId { get; set; }
    public UserEntity User { get; set; } = null!;
    public string? DocumentType { get; init; }
    public required string Country { get; init; }
    public required string ZipCode { get; init; }
    public required string AddressLine1 { get; init; }
    public string? AddressLine2 { get; init; }
    public string? AddressLine3 { get; init; }
    public double MinimumMonthlySalary { get; init; } //allows consideration of products to offer to ensure security
    public double MaximumMonthlySalary { get; init; }
    public required string FullName { get; init; }
    public required string DocumentImagePath { get; init; }
    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
}
public sealed class KycEntityConfiguration : IEntityTypeConfiguration<KycEntity>
{
    public void Configure(EntityTypeBuilder<KycEntity> builder)
    {
        builder.ToTable("kyc");

        builder.HasKey(k => k.Id);

        // one user can have many kyc attempts
        builder.HasOne(k => k.User)
               .WithMany(u => u.KycRecords)
               .HasForeignKey(k => k.UserId);
    }
}