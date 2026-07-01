using Api.Constants;

namespace Api.Repositories.LoanRequests;

public sealed record LoanRequestDto
{
    public long Id { get; set; }
    public long CustomerId { get; set; }
    public required string Name { get; set; }
    public long LoanProductId { get; set; }
    public required string LoanName { get; set; }
    public required decimal Amount { get; set; }
    public required decimal InterestRate { get; set; }
    public required decimal FinalAmount { get; set; }

    public required CommonStatus Status { get; set; }
    public required int Months { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedDateTime { get; set; }

}

public sealed record AddLoanRequestDto
{
    public long CustomerId { get; set; }
    public required string Name { get; set; }
    public long LoanProductId { get; set; }
    public required string LoanName { get; set; }
    public required decimal Amount { get; set; }
    public required decimal InterestRate { get; set; }
    public required decimal FinalAmount { get; set; }

    public required CommonStatus Status { get; set; }
    public required int Months { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedDate { get; set; }
}
