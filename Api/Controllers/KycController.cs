using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Entities.Kycs;

[ApiController]
[Route("api/[controller]")]

public class KycController : ControllerBase
{
    private readonly AppDbContext _db;
    public KycController(AppDbContext db) => _db = db;

    [HttpPost]
    public async Task<IActionResult> CreateKyc([FromBody] CreateKycRequest req)
    {
        var customerExists = await _db.Customers.AnyAsync(u => u.Id == req.CustomerId);
        if (!customerExists)
            return NotFound(new { message = "User not found." });

        var kyc = new KycEntity
        {
            CustomerId = req.CustomerId,
            DocumentType = req.DocumentType,
            Country = req.Country,
            ZipCode = req.ZipCode,
            AddressLine1 = req.AddressLine1,
            AddressLine2 = req.AddressLine2,
            AddressLine3 = req.AddressLine3,
            FullName = req.FullName,
            DocumentImagePath = req.DocumentImagePath,
            SubmittedBy = req.SubmittedBy
        };

        _db.Kycs.Add(kyc);
        await _db.SaveChangesAsync();

        return Created($"/api/users/{kyc.Id}", new { kyc.Id, kyc.CustomerId });
    }
}

