using Api.Repositories.Customers;

public sealed record KycDto
{
    public long Id { get; init; }
    public long CustomerId { get; init; }
    public string? DocumentType { get; init; }
    public required string Country { get; init; }
    public required string ZipCode { get; init; }
    public required string AddressLine1 { get; init; }
    public string? AddressLine2 { get; init; }
    public string? AddressLine3 { get; init; }
    public required string FullName { get; init; }
    public DateOnly DateOfBirth { get; init; }
    public required string DocumentImagePath { get; init; }
    public required string SubmittedBy { get; set; }
}

public sealed record AddKycDto
{
    public long Id { get; init; }
    public long CustomerId { get; init; }
    public string? DocumentType { get; init; }
    public required string Country { get; init; }
    public required string ZipCode { get; init; }
    public required string AddressLine1 { get; init; }
    public string? AddressLine2 { get; init; }
    public string? AddressLine3 { get; init; }
    public required string FullName { get; init; }
    public DateOnly DateOfBirth { get; init; }
    public required string DocumentImagePath { get; init; }
    public required string SubmittedBy { get; set; }
}