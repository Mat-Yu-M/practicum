using Api.Constants;

namespace Api.Repositories.CustomerLoanHistories
{
    public sealed record CustomerLoanHistoryDto
    {
        public long CustomerId { get; init; }
        public long LoanId { get; init; }
        public decimal LoanAmount { get; init; }
        public CommonStatus Status { get; init; }
        public long RepaymentScheduleId { get; init; }
        public DateTime DueDate { get; init; }
        public required string CreatedBy { get; init; }
        public required DateTime CreatedDateTime { get; init; }
        public required string ApprovedBy { get; init; }
        public required DateTime ApprovedAt { get; init; }
    }

    public sealed record AddCustomerLoanHistoryDto
    {
        public long CustomerId { get; init; }
        public long LoanId { get; init; }
        public decimal LoanAmount { get; init; }
        public CommonStatus Status { get; init; }
        public long RepaymentScheduleId { get; init; }
        public DateTime DueDate { get; init; }
        public required string CreatedBy { get; init; }
        public required DateTime CreatedDateTime { get; init; }
        public required string ApprovedBy { get; init; }
        public required DateTime ApprovedAt { get; init; }
    }
}
