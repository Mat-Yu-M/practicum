using Api.Constants;
using Api.Entities.LoanRequests;

namespace Api.Repositories.LoanRequests;

public sealed record LoanRequestDto
{
    public long Id { get; set; }
    public long CustomerId { get; set; } = 0;
    public required string Name { get; set; }
    public long LoanProductId { get; set; }
    public required string LoanName { get; set; }
    public required string Description { get; set; }
    public required decimal Amount { get; set; }
    public required decimal InterestRate { get; set; }
    public required CommonStatus Status { get; set; }
    public required LoanRequestType RequestType { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedDateTime { get; set; }

}

public sealed record AddLoanRequestDto
{
    public long Id { get; set; }
    public long CustomerId { get; set; } = 0;
    public required string Name { get; set; }
    public long LoanProductId { get; set; }
    public required string LoanName { get; set; }
    public required string Description { get; set; }
    public required decimal Amount { get; set; }
    public required decimal InterestRate { get; set; }
    public required CommonStatus Status { get; set; }
    public required LoanRequestType RequestType { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedDate { get; set; }
}
