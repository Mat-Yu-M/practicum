using Api.Constants;
using Api.Entities.CustomerStatusHistories;
using Api.Entities.EmailDetails;
using Api.Entities.Kycs;
using Api.Entities.PhoneDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.Customers;

public sealed class CustomerEntity
{
    public long Id { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? Suffix { get; set; }
    public required string LastName { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public decimal Balance { get; set; } = 0;
    public CustomerStatus Status { get; set; }
    public string CreatedBy { get; init; }
    public DateTime CreatedDateTime { get; init; } = DateTime.UtcNow;
    public ICollection<KycEntity> KycDetails { get; set; } = [];
    public ICollection<PhoneDetailEntity> PhoneDetails { get; set; } = [];
    public ICollection<EmailDetailEntity> EmailDetails { get; set; } = [];
    public ICollection<CustomerLoanHistoryEntity> CustomerLoanHistory { get; set; } = [];
    public ICollection<CustomerStatusHistoryEntity> CustomerStatusHistory { get; set; } = [];
}

public sealed class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable("customers");

        builder.HasKey(u => u.Id);

        builder
        .HasMany(c => c.EmailDetails)
        .WithOne(ed => ed.Customer)
        .HasForeignKey(ed => ed.CustomerId);

        builder
        .HasMany(c => c.PhoneDetails)
        .WithOne(pd => pd.Customer)
        .HasForeignKey(pd => pd.CustomerId);

        builder
        .HasMany(c => c.CustomerStatusHistory)
        .WithOne(csh => csh.Customer)
        .HasForeignKey(csh => csh.CustomerId);
    }
}