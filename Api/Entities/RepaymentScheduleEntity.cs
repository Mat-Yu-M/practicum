
    public sealed record RepaymentScheduleEntity
    {
        public long Id { get; init; }
        public long LoanId { get; init; }
        public long UserId { get; init; }
        public decimal Amount { get; init; }
        public decimal Balance { get; init; }
        public decimal InterestRate { get; init; }
        public DateTime DueDate { get; init; }
    }

