using Api.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities;

public sealed class EmployeeEntity
{
    public long Id { get; init; }
    public long EmployeeId { get; init; } = 0;
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required List<EmployeeRoles> EmployeeRoles { get; init; }
    public required string CreatedBy { get; init; }
    public DateTime? CreatedDate { get; init; }
}

public sealed class EmployeeEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.ToTable("employees");   
        builder.HasKey(e => e.Id);
    }
}