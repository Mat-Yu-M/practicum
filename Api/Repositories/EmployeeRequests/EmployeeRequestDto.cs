using Api.Constants;
using Api.Entities.EmployeeRequests;

namespace Api.Repositories.EmployeeRequests
{
    public sealed record EmployeeRequestDto
    {
        public required long Id { get; init; }
        public required string EmployeeId { get; init; }
        public required string FirstName { get; init; }
        public required string MiddleName { get; init; }
        public required string LastName { get; init; }
        public required string? Suffix { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required List<EmployeeRoles> EmployeeRoles { get; init; }
        public required EmployeeRoleRequestType RequestType { get; init; }
        public required string CreatedBy { get; init; }
        public required DateTime CreatedDateTime { get; init; }
    }
    public sealed record RegisterEmployeeRequestDto
    {
        public required string EmployeeId { get; init; }
        public required string FirstName { get; init; }
        public required string MiddleName { get; init; }
        public required string LastName { get; init; }
        public required string? Suffix { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required List<EmployeeRoles> EmployeeRoles { get; init; }
        public required EmployeeRoleRequestType RequestType { get; init; }
        public required string CreatedBy { get; init; }
        public required DateTime CreatedDateTime { get; init; }
    }
}
