using Api.Constants;

namespace Api.Entities.LoanRequests
{
    public record LoanRequestRequest(
    long CustomerId,
    string Name,
    long LoanProductId,
    string LoanName,
    decimal Amount,
    decimal InterestRate,
    CommonStatus Status,
    LoanRequestType RequestType,
    DateTime StartDate,
    DateTime EndDate,
    string CreatedBy,
    DateTime CreatedDateTime
    );

    public record LoanRequestResponse(
    string Name,
    string LoanName,
    string CreatedBy,
    DateTime CreatedDateTime
    );
}
