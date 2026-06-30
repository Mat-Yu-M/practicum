namespace Api.Entities.PhoneDetails;

public record PhoneDetailRequest
(
long CustomerId,
string PhoneNumber,
string CreatedBy,
DateTime CreatedDateTime
);

public record PhoneDetailResponse
(
long CustomerId,
string PhoneNumber,
string CreatedBy,
DateTime CreatedDateTime
);

