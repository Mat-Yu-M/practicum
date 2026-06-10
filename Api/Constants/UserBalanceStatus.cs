namespace Api.Constants;
    public enum UserBalanceStatus
    {
    // Has an active/ongoing loan
    Active,           // or: HasActiveLoan, Borrowing

    // Never had a loan / no loan history
    NoLoanHistory,    // or: Clean, Unborrowed, FirstTime

    // Wants a loan but can't get one (bad standing)
    Delinquent,       // or: Defaulted, Blacklisted, Ineligible
}

