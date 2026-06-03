
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed record RepaymentScheduleEntity
    {
        public long Id { get; init; }
        public long LoanId { get; init; }
        public long UserId { get; init; }
        public decimal Amount { get; init; }
        public decimal Balance { get; init; }
        public decimal InterestRate { get; init; }
        public DateTime DueDate { get; init; }
    }

public sealed class RepaymentScheduleEntityConfiguration : IEntityTypeConfiguration<RepaymentScheduleEntity>

{

    public void Configure(EntityTypeBuilder<RepaymentScheduleEntity> builder)

    {

        builder.ToTable("repayment_schedules");

        builder.HasKey(rs => rs.Id);

    }

}