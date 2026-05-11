using Api.Constants;
using Microsoft;

namespace Api.Repositories.Employees;

public sealed record EmployeeDto
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
    public DateTime? CreatedDateTime { get; init; }
}
public sealed record AddEmployeeDto
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
    public DateTime? CreatedDateTime { get; init; }

}

public sealed record UpdateEmployeeDto
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
    public DateTime? CreatedDateTime { get; init; }
}

public sealed record RegisterEmployeeDto
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
    public DateTime? CreatedDateTime { get; init; }
}