using Api.Constants;
using Api.Entities.EmployeeRequests;

namespace Api.Entities.Employees
{
    public record CreateEmployeeRequest
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
    DateTime CreatedDateTime,
    string ApprovedBy,
    DateTime ApprovedDateTime
    );
}
