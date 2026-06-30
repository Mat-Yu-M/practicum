using Api.Constants;
using Api.Entities.CustomerLoanHistories;
using Api.Entities.CustomerStatusHistories;
using Api.Entities.EmailDetails;
using Api.Entities.Kycs;
using Api.Entities.PhoneDetails;

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
    DateTime CreatedDateTime,
        IEnumerable<EmailDetailResponse> EmailDetails,
    IEnumerable<PhoneDetailResponse> PhoneDetails,
    IEnumerable<KycResponse> KycDetails,
    IEnumerable<CustomerStatusHistoryResponse> CustomerStatusHistories,
    IEnumerable<CustomerLoanHistoryResponse> CustomerLoanHistories
);