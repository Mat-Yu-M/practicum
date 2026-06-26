using Api.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.LoanProducts;

public sealed class LoanProductEntity
{
    public long Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required LoanCategory LoanCategory { get; init; }
    public decimal InterestRate { get; init; }
    public decimal MinimumAmount { get; init; }
    public decimal MaximumAmount { get; init; }
    public int MinimumTermMonths { get; init; }
    public int MaximumTermMonths { get; init; }
    public bool IsPromotion { get; init; }
    public required string CreatedBy { get; init; }
    public DateTime CreatedDateTime { get; init; }
    public required string ApprovedBy { get; init; }
    public DateTime ApprovedDateTime { get; init; }

}

public sealed class LoanProductEntityConfiguration : IEntityTypeConfiguration<LoanProductEntity>
{
    public void Configure(EntityTypeBuilder<LoanProductEntity> builder)
    {
        builder.ToTable("loan_products");
        builder.HasKey(lp => lp.Id);
    }
}