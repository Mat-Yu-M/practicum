using Api.Constants;

public sealed record LoanDto
{
    public long Id { get; set; }
    public long UserId { get; set; } = 0;
    public required string Name { get; set; }
    public long LoanProductId { get; set; }
    public required string LoanName { get; set; }
    public required string Description { get; set; }
    public required decimal Amount { get; set; }
    public required decimal InterestRate { get; set; }
    public required CommonStatus Status { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required DateTime ApprovedDate { get; set; }
    public required string ApprovedBy { get; set; }
    public required DateTime CreatedDate { get; set; }

}

public sealed record AddLoanDto
{
    public long Id { get; set; }
    public long UserId { get; set; } = 0;
    public required string Name { get; set; }
    public long LoanProductId { get; set; }
    public required string LoanName { get; set; }
    public required string Description { get; set; }
    public required decimal Amount { get; set; }
    public required decimal InterestRate { get; set; }
    public required CommonStatus Status { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required DateTime ApprovedDate { get; set; }
    public required string ApprovedBy { get; set; }
    public required DateTime CreatedDate { get; set; }

}