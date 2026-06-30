using Api.Entities.Customers;
using Api.Entities.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed record RepaymentScheduleEntity
{
    public long Id { get; init; }
    public long LoanId { get; init; }
    public long CustomerId { get; init; }
    public int InstallmentNumber { get; init; }
    public decimal TotalAmountDue { get; init; }
    public decimal PrincipalAmount { get; init; }
    public decimal InterestAmount { get; init; }
    public decimal RemainingBalance { get; init; }
    public DateTime DueDate { get; init; }
    public bool IsPaid { get; set; } = false;
}

public sealed class RepaymentScheduleEntityConfiguration : IEntityTypeConfiguration<RepaymentScheduleEntity>
{
    public void Configure(EntityTypeBuilder<RepaymentScheduleEntity> builder)
    {
        builder.ToTable("repayment_schedules");

        builder.HasKey(rs => rs.Id);

        builder.Property(r => r.PrincipalAmount).HasPrecision(18, 2);
        builder.Property(r => r.InterestAmount).HasPrecision(18, 2);
        builder.Property(r => r.RemainingBalance).HasPrecision(18, 2);

        builder.HasOne<LoanEntity>()
            .WithMany()
            .HasForeignKey(rs => rs.LoanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<CustomerEntity>()
            .WithMany()
            .HasForeignKey(rs => rs.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

    }

}