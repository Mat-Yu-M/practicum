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
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }

    public sealed record AddLoanProductDto
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
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }