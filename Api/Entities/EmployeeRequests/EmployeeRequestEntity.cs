using Api.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.EmployeeRequests
{
    public class EmployeeRequestEntity
    {
        public long Id { get; init; }
        public required string EmployeeId { get; init; }
        public required string FirstName { get; init; }
        public required string MiddleName { get; init; }
        public required string LastName { get; init; }
        public required string? Suffix { get; init; }
        public required string Email { get; init; }        
        public required string Password { get; init; }
        public required List<EmployeeRoles> EmployeeRoles { get; init; }
        public required EmployeeRequestType RequestType { get; init; }
        public required string CreatedBy { get; init; }
        public required DateTime CreatedDateTime { get; init; } 
    }

    public sealed class EmployeeRequestEntityConfiguration : IEntityTypeConfiguration<EmployeeRequestEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeRequestEntity> builder)
        {
            builder.ToTable("employees_request");
            builder.HasKey(e => e.Id);
        }
    }
}

