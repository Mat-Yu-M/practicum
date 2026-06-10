using Api.Constants;

namespace Api.Repositories.Customers;
public sealed record CustomerDto
{
    public long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public string? Suffix { get; init; } = string.Empty;
    public required UserStatus Status { get; init; }
    public required decimal Balance { get; init; }
    public required DateTime CreatedDateTime { get; init; } = DateTime.UtcNow;
}

public sealed record AddCustomerDto
{
    public long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public string? Suffix { get; init; } = string.Empty;
    public required UserStatus Status { get; init; }
    public required decimal Balance { get; init; } = 0;
    public required DateTime CreatedDateTime { get; init; }
}

public sealed record UpdateCustomerDto
{
    public long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public string? Suffix { get; init; } = string.Empty;
    public required UserStatus Status { get; init; }
    public required decimal Balance { get; init; }
    public required DateTime CreatedDateTime { get; init; }
}

public sealed record RegisterCustomerDto
{
    public long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public string? Suffix { get; init; } = string.Empty;
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required UserStatus Status { get; init; }
    public required decimal Balance { get; init; }
    public required DateTime CreatedDateTime { get; init; }
}
