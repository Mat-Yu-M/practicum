namespace Api.Entities.EmailDetails
{
    public record EmailDetailResponse
    (
    long CustomerId,
    string Email,
    string CreatedBy,
    string CreatedDateTime
    );
}
