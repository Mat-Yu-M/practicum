namespace Api.Constants
{
    public enum CustomerStatus
    {
        // Waiting for customer to submit requirements
        PendingRequirements,

        // Employee just encoded the customer's basic info
        Encoded,

        // Requirements submitted, under review by staff
        UnderReview,

        // Requirements incomplete or has issues, sent back
        RequirementsRejected,

        // Fully verified, eligible to apply for a loan
        Verified,

        // Verified but currently has an active loan
        ActiveBorrower,

        // Loan fully paid, in good standing
        Cleared,

        // Missed payments, in bad standing
        Delinquent,

        // Fully failed to repay
        Defaulted,

        // Banned / can no longer transact
        Blacklisted,

        // Account deactivated or dormant
        Inactive
    }
}
