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
    List<EmployeeRoles> EmployeeRoles,
    string CreatedBy,
    DateTime CreatedDate,
    string ApprovedBy,
    DateTime ApprovedDate
    );
}
