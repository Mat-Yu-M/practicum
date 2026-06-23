using Api.Constants;

namespace Api.Entities.LoanProducts;

public record CreateLoanProductRequest(
long Id,
string Name,
string Description,
LoanCategory LoanCategory,
decimal InterestRate,
decimal MinimumAmount,
decimal MaximumAmount,
int MinimumTermMonths,
int MaximumTermMonths,
bool IsPromotion
);

