namespace Api.Repositories.EmailDetails
{
    public sealed record EmailDetailDto
    {
        public long CustomerId { get; init; }
        public required string Email { get; init; }
        public required string CreatedBy { get; init; }
        public required DateTime CreatedDateTime { get; init; }
    }
    public sealed record AddEmailDetailDto
    {
        public long CustomerId { get; init; }
        public required string Email { get; init; }
        public required string CreatedBy { get; init; }
        public required DateTime CreatedDateTime { get; init; }
    }
}
