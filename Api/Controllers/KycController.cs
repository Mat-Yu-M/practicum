using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Entities;
using Api.Constants;

[ApiController]
[Route("api/[controller]")]

public class KycController : ControllerBase
{
    private readonly AppDbContext _db;
    public KycController(AppDbContext db) => _db = db;

    [HttpPost]
    public async Task<IActionResult> CreateKyc([FromBody] CreateKycRequest req)
    {
        var userExists = await _db.Users.AnyAsync(u => u.Id == req.UserId);
        if (!userExists)
            return NotFound(new { message = "User not found." });

        var kyc = new KycEntity
        {
            User = req.User,
            DocumentType = req.DocumentType,
            Country = req.Country,
            ZipCode = req.ZipCode,
            AddressLine1 = req.AddressLine1,
            AddressLine2 = req.AddressLine2,
            AddressLine3 = req.AddressLine3,
            MinimumMonthlySalary = req.MinimumMonthlySalary,
            MaximumMonthlySalary = req.MaximumMonthlySalary,
            FullName = req.FullName,
            DocumentImagePath = req.DocumentImagePath,
        };

        _db.Kyc.Add(kyc);
        await _db.SaveChangesAsync();

        return Created($"/api/users/{kyc.Id}", new { kyc.Id, kyc.UserId });
    }
}

public record CreateKycRequest(
int UserId,
UserEntity User,
string? DocumentType,
string Country,
string ZipCode,
string AddressLine1,
string? AddressLine2,
string? AddressLine3,
double MinimumMonthlySalary,
double MaximumMonthlySalary,
string FullName,
string DocumentImagePath
);