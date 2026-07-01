using Api.Constants;

public sealed record LoanDto
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
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required DateTime ApprovedDateTime { get; set; }
    public required string ApprovedBy { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedDateTime { get; set; }

}

public sealed record AddLoanDto
{
    public long CustomerId { get; set; }
    public required string Name { get; set; }
    public long LoanProductId { get; set; }
    public required string LoanName { get; set; }
    public required decimal Amount { get; set; }
    public required decimal InterestRate { get; set; }
    public required decimal FinalAmount { get; set; }
    public required CommonStatus Status { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedDateTime { get; set; }
    public required string ApprovedBy { get; set; }
    public required DateTime ApprovedDateTime { get; set; }



}