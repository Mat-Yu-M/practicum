using Api.Constants;

namespace Api.Entities.CustomerStatusHistories
{
    public record CustomerStatusRequest
    (
    long CustomerId,
    CustomerStatus BeforeStatus,
    CustomerStatus AfterStatus,
    string CreatedBy,
    DateTime CreatedDateTime
    );

    public record CustomerStatusHistoryResponse(
    long CustomerId,
    string CustomerName,
    CustomerStatus BeforeStatus,
    CustomerStatus AfterStatus,
    string CreatedBy,
    DateTime? CreatedDateTime
    );
}
