using Api.Constants;

namespace Api.Entities.LoanProducts;

public record CreateLoanProductRequest(
string Name,
string Description,
LoanCategory LoanCategory,
decimal InterestRate,
decimal MinimumAmount,
decimal MaximumAmount,
int MinimumTermMonths,
int MaximumTermMonths,
bool IsPromotion,
string CreatedBy,
DateTime CreatedDateTime,
string ApprovedBy,
DateTime ApprovedDateTime
);

public record LoanProductResponse
(
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

