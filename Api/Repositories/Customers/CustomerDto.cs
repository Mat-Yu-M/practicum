namespace Api.Repositories.Customers;
public sealed record UserDto
{
    public long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; } 
    public required string Password { get; init; }
    public required DateTime CreatedDateTime { get; init; }
    public string? ModifiedBy { get; init; }
    public DateTime? ModifiedDateTime { get; init; }
    public string FullName => $"{FirstName} {MiddleName} {LastName}".Replace("  ", " ").Trim();
}

public sealed record AddUserDto
{
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string CreatedBy { get; init; }
}

public sealed record UpdateUserDto
{
    public long Id { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string ModifiedBy { get; init; }
}

public sealed record RegisterUserDto
{
    public required string FirstName { get; init; }
    public required string? MiddleName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}