using Api.Constants;
using k8s.Models;

namespace Api.Entities.Customers;

public record UpdateCustomerStatusRequest(UserStatus Status);

public record UpdateBalanceRequest(decimal Balance);

public record UpdateCustomerRequest(
string FirstName,
string MiddleName,
string LastName,
string Email,
decimal Balance,
UserBalanceStatus UserBalanceStatus,
UserStatus Status
);

public record CreateCustomerRequest(
    string Id,
string FirstName,
string MiddleName,
string LastName,
decimal Balance
);