using Api.Constants;

namespace Api.Entities;

public sealed class UserEntity
{
    public long Id { get; set; }
    public required string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PasswordHasher { get; set; }
    public DateTime CreatedDateTime { get; init; } = DateTime.UtcNow;
    public UserStatus Status { get; set; }
}