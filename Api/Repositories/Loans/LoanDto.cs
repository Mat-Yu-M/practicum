public sealed record LoanDto
{
    public long Id { get; set; }
    public long UserId { get; set; } = 0;
    public required string Name { get; set; }
    public long LoanId { get; set; }
    public required string LoanName { get; set; }
    public required string Description { get; set; }
    public required decimal Amount { get; set; }
    public required decimal InterestRate { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required DateTime ApprovedDate { get; set; }
    public required DateTime ApprovedBy { get; set; }
    public required DateTime CreatedDate { get; set; }

}

public sealed record AddLoanDto
{

}