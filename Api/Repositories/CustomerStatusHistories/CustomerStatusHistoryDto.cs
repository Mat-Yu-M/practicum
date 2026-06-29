using Api.Constants;

namespace Api.Repositories.CustomerStatusHistories;

public sealed record CustomerStatusHistoryDto
{
    public required long Id { get; init; }
    public required long CustomerId { get; init; }
    public required string CustomerName { get; init; }
    public required CustomerStatus BeforeStatus { get; init; }
    public required CustomerStatus AfterStatus { get; init; }
    public required string CreatedBy { get; init; }
    public required DateTime CreatedDateTime { get; init; }
}

public sealed record AddCustomerStatusHistoryDto
{
    public required long CustomerId { get; init; }
    public required string CustomerName { get; init; }
    public required CustomerStatus BeforeStatus { get; init; }
    public required CustomerStatus AfterStatus { get; init; }
    public string CreatedBy { get; init; }
    public DateTime CreatedDateTime { get; init; }
}