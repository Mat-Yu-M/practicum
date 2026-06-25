using Api.Constants;

namespace Api.Repositories.Employees;

public sealed record EmployeeDto
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
    public required string ApprovedBy { get; init; }
    public required DateTime ApprovedDateTime { get; init; }
    public required string CreatedBy { get; init; }
    public required DateTime CreatedDateTime { get; init; }
}
public sealed record RegisterEmployeeDto
{
    public required string EmployeeId { get; init; }
    public required string FirstName { get; init; }
    public required string MiddleName { get; init; }
    public required string LastName { get; init; }
    public required string? Suffix { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required List<EmployeeRoles> EmployeeRoles { get; init; }
    public required string ApprovedBy { get; init; }
    public required DateTime ApprovedDateTime { get; init; }
    public required string CreatedBy { get; init; }
    public required DateTime CreatedDateTime { get; init; }
}