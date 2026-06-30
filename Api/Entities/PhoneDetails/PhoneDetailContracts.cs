namespace Api.Entities.PhoneDetails;

public record PhoneDetailResponse
(
long CustomerId,
string PhoneNumber,
string CreatedBy,
DateTime CreatedDateTime
);

