using Api.Constants;

namespace Api.Entities.CustomerLoanHistories
{
    public record CustomerLoanHistoryResponse
    (
    long CustomerId,
    long LoanId,
    decimal LoanAmount,
    CommonStatus Status,
    long RepaymentScheduleId,
    DateTime DueDate,
    string CreatedBy,
    DateTime CreatedDateTime,
    string ApprovedBy,
    DateTime ApprovedAt
    );
}
