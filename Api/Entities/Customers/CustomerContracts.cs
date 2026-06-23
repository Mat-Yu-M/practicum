using Api.Constants;
using k8s.Models;

namespace Api.Entities.Customers;

public record UpdateCustomerStatusRequest(CustomerStatus Status);

public record UpdateBalanceRequest(decimal Balance);

public record UpdateCustomerRequest(
string FirstName,
string MiddleName,
string LastName,
decimal Balance,
CustomerBalanceStatus UserBalanceStatus,
CustomerStatus Status
);

public record CreateCustomerRequest(
string Id,
string FirstName,
string MiddleName,
string LastName,
string Suffix,
DateOnly DateOfBirth
);