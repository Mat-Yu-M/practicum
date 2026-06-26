using Api.Constants;

namespace Api.Entities.LoanProductRequests;

public record AddLoanProductRequestRequest
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
bool IsPromotion,
LoanProductRequestType RequestType,
string CreatedBy,
DateTime CreatedDateTime
);

