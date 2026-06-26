using Api.Constants;
using Api.Entities.LoanProducts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.Loans;

public sealed class LoanEntity
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public required string Name { get; set; }
    public long LoanProductId { get; set; }
    public required string LoanName { get; set; }
    public required string Description { get; set; }
    public required decimal Amount { get; set; }
    public required decimal InterestRate { get; set; }
    public required CommonStatus Status { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required DateTime ApprovedDateTime { get; set; }
    public required string ApprovedBy { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedDateTime { get; set; }

}

public sealed class LoanEntityConfiguration : IEntityTypeConfiguration<LoanEntity>
{
    public void Configure(EntityTypeBuilder<LoanEntity> builder)
    {
        builder.ToTable("loans");
        builder.HasKey(l => l.Id);

        builder.HasOne<LoanProductEntity>()
               .WithMany()
               .HasForeignKey(l => l.LoanProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}