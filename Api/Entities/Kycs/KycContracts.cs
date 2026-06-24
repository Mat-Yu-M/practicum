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

