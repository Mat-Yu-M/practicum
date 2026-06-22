using Api.Constants;
using Api.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.CustomerRequests
{
    public sealed class CustomerRequestEntity
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? Suffix { get; set; }
        public required string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public CustomerStatus Status { get; set; }
        public CustomerRequestType RequestType { get; set; }
        public CustomerRequestStatusType RequestStatusType { get; set; }      
        public string? RejectionReason { get; set; }
        public long? CustomerId { get; set; }
        public CustomerEntity? Customer { get; set; }
        public long CreatedBy { get; init; }
        public DateTime CreatedDateTime { get; init; } = DateTime.UtcNow;
    }

    public sealed class CustomerRequestEntityConfiguration : IEntityTypeConfiguration<CustomerRequestEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerRequestEntity> builder)
        {
            builder.ToTable("customer_request");
            builder.HasKey(cr => cr.Id);
        }
    }
}
