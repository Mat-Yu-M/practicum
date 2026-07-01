using Api.Constants;

namespace Api.Entities.Loans;

public record AddLoanRequest
(
    long CustomerId,
    string Name,
    long LoanProductId,
    string LoanName,
    decimal Amount,
    decimal InterestRate,
    decimal FinalAmount,
    CommonStatus Status,
    DateTime StartDate,
    DateTime EndDate,
    string CreatedBy,
    DateTime CreatedDateTime,
    string ApprovedBy,
    DateTime ApprovedDateTime
);

