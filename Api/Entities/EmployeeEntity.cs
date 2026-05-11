using Api.Constants;

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