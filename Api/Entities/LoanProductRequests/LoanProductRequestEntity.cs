using Api.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.LoanProductRequests
{
    public sealed class LoanProductRequestEntity
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
        public required LoanProductRequestType RequestType { get; init; }
        public required string CreatedBy { get; init; }
        public DateTime CreatedDateTime { get; init; }
    }

    public sealed class LoanProductRequestEntityConfiguration : IEntityTypeConfiguration<LoanProductRequestEntity>
    {
        public void Configure(EntityTypeBuilder<LoanProductRequestEntity> builder)
        {
            builder.ToTable("loan_product_requests");
            builder.HasKey(e => e.Id);
        }
    }
}
