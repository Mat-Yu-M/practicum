using Api.Constants;
using Api.Entities.Customers;
using Api.Entities.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed record CustomerLoanHistoryEntity
{
    public long Id { get; init; }
    public long CustomerId { get; init; }
    public long LoanId { get; init; }
    public decimal LoanAmount { get; init; }
    public CommonStatus Status { get; init; }
    public long RepaymentScheduleId { get; init; }
    public DateTime DueDate { get; init; }
    public required string CreatedBy { get; init; }
    public required DateTime CreatedDateTime { get; init; }
    public required string ApprovedBy { get; init; }
    public required DateTime ApprovedAt { get; init; }
    public CustomerEntity Customer { get; init; } = null!;
}

public sealed class CustomerHistoryEntityConfiguration : IEntityTypeConfiguration<CustomerLoanHistoryEntity>
{
    public void Configure(EntityTypeBuilder<CustomerLoanHistoryEntity> builder)
    {
        builder.ToTable("customer_loan_history");

        builder.HasKey(ch => ch.Id);

        builder.Property(ch => ch.LoanAmount)
           .HasPrecision(18, 2);

        builder.HasOne(ch => ch.Customer)
               .WithMany(c => c.CustomerLoanHistory)
               .HasForeignKey(ch => ch.CustomerId);

        builder.HasOne<LoanEntity>()
               .WithMany()
               .HasForeignKey(ch => ch.LoanId);

        builder.HasOne<RepaymentScheduleEntity>()
               .WithMany()
               .HasForeignKey(ch => ch.RepaymentScheduleId);
    }
}