using Api.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.LoanRequests
{
    public sealed class LoanRequestEntity
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
        public required LoanRequestType RequestType { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required DateTime ApprovedDate { get; set; }
        public required string ApprovedBy { get; set; }
        public required DateTime CreatedDate { get; set; }
    }
    
    public sealed class LoanRequestEntityConfiguration : IEntityTypeConfiguration<LoanRequestEntity>
    {
        public void Configure(EntityTypeBuilder<LoanRequestEntity> builder)
        {
            builder.ToTable("loan_requests");
            builder.HasKey(e => e.Id);

        }
    }

}
