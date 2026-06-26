using Api.Constants;

namespace Api.Repositories.LoanProducts;

public sealed record LoanProductDto
{
    public long Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required LoanCategory LoanCategory { get; init; }
    public decimal InterestRate { get; init; }
    public decimal MinimumAmount { get; init; }
    public decimal MaximumAmount { get; init; }
    public int MinimumTermMonths { get; init; }
    public int MaximumTermMonths { get; init; }
    public required bool IsPromotion { get; init; } = false;
    public required string CreatedBy { get; init; }
    public DateTime CreatedDateTime { get; init; }
    public required string ApprovedBy { get; init; }
    public DateTime ApprovedDateTime { get; init; }
}

public sealed record AddLoanProductDto
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required LoanCategory LoanCategory { get; init; }
    public decimal InterestRate { get; init; }
    public decimal MinimumAmount { get; init; }
    public decimal MaximumAmount { get; init; }
    public int MinimumTermMonths { get; init; }
    public int MaximumTermMonths { get; init; }
    public required bool IsPromotion { get; init; } = false;
    public required string CreatedBy { get; init; }
    public DateTime CreatedDateTime { get; init; }
    public required string ApprovedBy { get; init; }
    public DateTime ApprovedDateTime { get; init; }

}