using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Entities;
using Api.Constants;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;
    public UsersController(AppDbContext db) => _db = db;

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest req)
    {
        if (await _db.Users.AnyAsync(u => u.Email == req.Email))
            return Conflict(new { message = "Email already in use." });

        var user = new UserEntity
        {
            FirstName = req.FirstName,
            MiddleName = req.MiddleName,
            LastName = req.LastName,
            Email = req.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
            Status = UserStatus.Unverified,
            Balance = req.Balance
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return Created($"/api/users/{user.Id}", new { user.Id, user.Email });
    }


    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _db.Users.ToListAsync();

        if (users == null)
            return NotFound(new { message = "No users found." });

        return Ok(users.Select(u => new { u.Id, u.FirstName, u.LastName, u.Status, u.Balance }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest req)
    {
        var user = await _db.Users.FindAsync(id);

        if (user == null)
            return NotFound(new { message = "User not found." });

        user.FirstName = req.FirstName;
        user.MiddleName = req.MiddleName;
        user.LastName = req.LastName;
        user.Email = req.Email;
        user.Balance = req.Balance;

        await _db.SaveChangesAsync();

        return Ok(new { user.Id, user.FirstName, user.LastName, user.Email, user.Balance });
    }

    public record UpdateUserRequest(
    string FirstName,
    string MiddleName,
    string LastName,
    string Email,
    decimal Balance,
    UserStatus Status
    );

    public record CreateUserRequest(
    string FirstName,
    string MiddleName,
    string LastName,
    string Email,
    string Password,
    decimal Balance
    );
}