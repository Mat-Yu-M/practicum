using Api.Constants;
using Api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed record CustomerHistoryEntity
{
    public long Id { get; init; }
    public long UserId { get; init; }
    public long LoanId { get; init; }
    public decimal LoanAmount { get; init; }
    public CommonStatus Status { get; init; }
    public long RepaymentScheduleId { get; init; }
    public string? Action { get; init; }
    public string? ApprovedBy { get; init; }
    public DateTime ApprovedAt { get; init; } = DateTime.UtcNow;
}

public sealed class CustomerHistoryEntityConfiguration : IEntityTypeConfiguration<CustomerHistoryEntity>
{
    public void Configure(EntityTypeBuilder<CustomerHistoryEntity> builder)
    {
        builder.ToTable("customer_history");

        builder.HasKey(ch => ch.Id);
    }
}