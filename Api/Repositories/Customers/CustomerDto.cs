using Api.Constants;

namespace Api.Repositories.Customers;
public sealed record CustomerDto
{
    public required long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public string? Suffix { get; init; }
    public required CustomerStatus Status { get; init; }
    public required decimal Balance { get; init; }
    public required DateTime CreatedDateTime { get; init; }
}

public sealed record AddCustomerDto
{
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public string? Suffix { get; init; } = string.Empty;
    public required DateOnly DateOfBirth { get; init; }
}

public sealed record UpdateCustomerDto
{
    public required long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public string? Suffix { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public required CustomerStatus Status { get; init; }
}

public sealed record RegisterCustomerDto
{
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public string? Suffix { get; init; }
    public required DateOnly DateOfBirth { get; init; }
    public CustomerStatus Status { get; init; } = CustomerStatus.PendingRequirements;
}

public sealed record CustomerListItemDto
{
    public required long Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
}