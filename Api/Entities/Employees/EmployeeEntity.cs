using Api.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Entities.Employees;

public sealed class EmployeeEntity
{
    public long Id { get; init; }
    public required string EmployeeId { get; init; }
    public required string FirstName { get; init; }
    public required string MiddleName { get; init; }
    public required string LastName { get; init; }
    public string? Suffix { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required List<EmployeeRoles> EmployeeRoles { get; init; }
    public required string ApprovedBy { get; init; }
    public required DateTime ApprovedDateTime { get; init; }
    public required string CreatedBy { get; init; }
    public required DateTime CreatedDateTime { get; init; }

}

public sealed class EmployeeEntityConfiguration : IEntityTypeConfiguration<EmployeeEntity>
{
    public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
    {
        builder.ToTable("employees");
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
        .UseIdentityAlwaysColumn();

        builder.HasIndex(e => e.EmployeeId)
        .IsUnique();

        builder.HasIndex(e => e.Email)
        .IsUnique();

        builder.Property(e => e.EmployeeId)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(e => e.Password)
        .IsRequired()
        .HasMaxLength(255);
    }
}