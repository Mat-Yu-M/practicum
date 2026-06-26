using Api.Constants;
using Api.Entities.Customers;
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
    public string? Action { get; init; }
    public string? ApprovedBy { get; init; }
    public DateTime ApprovedAt { get; init; } = DateTime.UtcNow;
    public required CustomerEntity Customer { get; init; }
}

public sealed class CustomerHistoryEntityConfiguration : IEntityTypeConfiguration<CustomerLoanHistoryEntity>
{
    public void Configure(EntityTypeBuilder<CustomerLoanHistoryEntity> builder)
    {
        builder.ToTable("customer_loan_history");

        builder.HasKey(ch => ch.Id);
    }
}