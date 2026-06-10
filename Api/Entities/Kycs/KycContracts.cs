namespace Api.Entities.Kycs;
public record CreateKycRequest(
    int CustomerId,
    string? DocumentType,
    string Country,
    string ZipCode,
    string AddressLine1,
    string? AddressLine2,
    string? AddressLine3,
    double MinimumMonthlySalary,
    double MaximumMonthlySalary,
    string FullName,
    string DocumentImagePath,
    string SubmittedBy
);

