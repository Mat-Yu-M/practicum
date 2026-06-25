using Api.Constants;

namespace Api.Entities.EmployeeRequests;
public record CreateEmployeeRequestRequest
(
string FirstName,
string MiddleName,
string LastName,
string? Suffix,
string Email,
string Password,
string EmployeeId,
List<EmployeeRoles> EmployeeRoles,
EmployeeRequestType RequestType,
string CreatedBy,
DateTime CreatedDateTime
);