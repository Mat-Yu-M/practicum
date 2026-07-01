namespace Api.Repositories.PhoneDetails
{
    public class PhoneDetailDto
    {
        public long CustomerId { get; init; }
        public required string PhoneNumber { get; set; }
        public required string CreatedBy { get; set; }
        public required DateTime CreatedDateTime { get; set; }
    }

    public class AddPhoneDetailDto
    {
        public long CustomerId { get; init; }
        public required string PhoneNumber { get; set; }
        public required string CreatedBy { get; set; }
        public required DateTime CreatedDateTime { get; set; }
    }
}
