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