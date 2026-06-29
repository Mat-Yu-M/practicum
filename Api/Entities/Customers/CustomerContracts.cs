using Api.Constants;

namespace Api.Entities.Customers;

public record CreateCustomerRequest(
string FirstName,
string MiddleName,
string LastName,
string Suffix,
CustomerStatus Status,
decimal Balance,
DateOnly DateOfBirth,
DateTime CreatedDateTime
);

public record CustomerResponse(
    string EncryptedId,
    string FirstName,
    string? MiddleName,
    string? Suffix,
    string LastName,
    DateOnly DateOfBirth,
    decimal Balance,
    CustomerStatus Status,
    long CreatedBy,
    DateTime CreatedDateTime
);