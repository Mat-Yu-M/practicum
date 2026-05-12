using Api.Constants;

namespace Api.Repositories.Customers;
public sealed record UserDto
{
    public long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; } 
    public required UserStatus Status { get; init; }
    public required decimal Balance { get; init; }
    public required DateTime CreatedDateTime { get; init; } = DateTime.UtcNow;
}

public sealed record AddUserDto
{
    public long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required UserStatus Status { get; init; }
    public required decimal Balance { get; init; }
    public required DateTime CreatedDateTime { get; init; }
}

public sealed record UpdateUserDto
{
    public long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required UserStatus Status { get; init; }
    public required decimal Balance { get; init; }
    public required DateTime CreatedDateTime { get; init; }
}

public sealed record RegisterUserDto
{
    public long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required UserStatus Status { get; init; }
    public required decimal Balance { get; init; }
    public required DateTime CreatedDateTime { get; init; }
}