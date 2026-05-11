using Api.Constants;

namespace Api.Entities;

public sealed class EmployeeEntity
{
    public long Id { get; init; }
    public long EmployeeId { get; init; } = 0;
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Title { get; init; }
    public required EmployeeRoles EmployeeRoles { get; init; }
    public DateTime? CreatedDate { get; init; }
}