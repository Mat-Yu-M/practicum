using Api.Constants;
using Api.Entities.EmployeeRequests;
using System.Security.Cryptography.X509Certificates;

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
}
