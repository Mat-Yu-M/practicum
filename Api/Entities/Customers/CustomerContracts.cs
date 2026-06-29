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
    string CreatedBy,
    DateTime CreatedDateTime
);

public record CustomerResponse(
    long Id,
    string FirstName,
    string? MiddleName,
    string? Suffix,
    string LastName,
    DateOnly DateOfBirth,
    decimal Balance,
    CustomerStatus Status,
    string CreatedBy,
    DateTime CreatedDateTime
);