using Api.Constants;
using Api.Entities.Customers;

namespace Api.Entities.Kycs;

public record CreateKycRequest(
    long CustomerId,
    string FullName,
    string Country,
    string ZipCode,
    string AddressLine,
    string? DocumentType,
    string DocumentImagePath,
    string SubmittedBy
);

public record KycResponse(
    long CustomerId,
    string FullName,
    string Country,
    string ZipCode,
    string AddressLine,
    string? DocumentType,
    string DocumentImagePath,
    string SubmittedBy,
    string SubmittedDateTime
    );


public record ApproveKycResponse(
string FullName,
CommonStatus Status,
string SubmittedBy,
DateTime SubmittedAt,
string? ReviewedBy,
DateTime? ReviewedAt
);

public record ApproveKycRequest(
long Id,
long CustomerId,
string FullName,
CustomerEntity? Customer,
string? DocumentType,
string DocumentImagePath,
string Country,
string ZipCode,
string AddressLine,
CommonStatus Status,
string SubmittedBy,
DateTime SubmittedAt,
string ReviewedBy,
DateTime ReviewedAt
);