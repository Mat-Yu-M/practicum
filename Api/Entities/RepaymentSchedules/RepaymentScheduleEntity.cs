using Api.Entities.Loans;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed record RepaymentScheduleEntity
    {
    public long Id { get; init; }
    public long LoanId { get; init; }
    public long CustomerId { get; init; }

    public int InstallmentNumber { get; init; }

    public decimal TotalAmountDue => PrincipalAmount + InterestAmount;

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

        builder.HasOne<LoanEntity>()
               .WithMany()
               .HasForeignKey(rs => rs.LoanId)
               .OnDelete(DeleteBehavior.Cascade);
    }

}