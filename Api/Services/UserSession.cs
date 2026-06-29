using System.Security.Claims;

namespace Api.Services;

public interface IUserSession
{
    string? Email { get; }
    string? EmployeeId { get; }
}

public class UserSession : IUserSession
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserSession(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;
    public string? EmployeeId => _httpContextAccessor.HttpContext?.User?.FindFirst("employee_id")?.Value;
}