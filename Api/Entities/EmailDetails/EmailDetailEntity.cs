using Api.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.EmailDetails
{
    public sealed class EmailDetailEntity
    {
        public required long Id { get; init; }
        public required long CustomerId { get; init; }
        public required string Email { get; init; }
        public required CustomerEntity Customer { get; init; }

    }

    public sealed class EmailDetailTypeConfiguration : IEntityTypeConfiguration<EmailDetailEntity>
    {
        public void Configure(EntityTypeBuilder<EmailDetailEntity> builder)
        {
            builder.ToTable("email_details");
            builder.HasKey(ed => ed.Id);

            builder.HasIndex(a => new { a.CustomerId, a.Email }).IsUnique();
        }
    }

}
