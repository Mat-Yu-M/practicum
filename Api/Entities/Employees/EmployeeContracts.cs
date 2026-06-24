using Api.Constants;

namespace Api.Entities.Employees
{
    public record CreateEmployeeRequest
    (
    long Id,
    string FirstName,
    string MiddleName,
    string LastName,
    string? Suffix,
    string Email,
    string Password,
    string EmployeeId,
    List<EmployeeRoles> EmployeeRoles,
    string CreatedBy,
    DateTime CreatedDateTime,
    string ApprovedBy,
    DateTime ApprovedDateTime
    );
}
