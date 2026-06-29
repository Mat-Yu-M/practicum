using Api.Constants;
using Api.Entities.EmployeeRequests;

namespace Api.Entities.Employees
{
    public record CreateEmployeeResponse
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

    public record GetExistingEmployeeRequest
    (
    string Email,
    string Password
    );

    public record EmployeeResponse(
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

    public record DeleteEmployeeRequest(
        string EmployeeId,
        string Email
        )
    {

    };
}
