using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Entities.Kycs;

[ApiController]
[Route("api/[controller]")]

public class KycController : ControllerBase
{
    private readonly AppDbContext _db;
    public KycController(AppDbContext db) => _db = db;

    [HttpPost("documents")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateKyc([FromForm] CreateKycRequest req)
    {
        var customerExists = await _db.Customers.AnyAsync(u => u.Id == req.CustomerId);
        if (!customerExists)
            return NotFound(new { message = "User not found." });

        if (req.DocumentFile == null || req.DocumentFile.Length == 0)
            return BadRequest(new { message = "A valid document file upload is required." });

        string savedRelativePath;
        try
        {
            string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(req.DocumentFile.FileName)}";

            string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            string absoluteFilePath = Path.Combine(uploadFolder, uniqueFileName);

            using (var stream = new FileStream(absoluteFilePath, FileMode.Create))
            {
                await req.DocumentFile.CopyToAsync(stream);
            }

            savedRelativePath = $"/uploads/{uniqueFileName}";
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Failed to save file system asset.", detail = ex.Message });
        }

        var kyc = new KycEntity
        {
            CustomerId = req.CustomerId,
            DocumentType = req.DocumentType,
            Country = req.Country,
            ZipCode = req.ZipCode,
            AddressLine = req.AddressLine,
            FullName = req.FullName,
            DocumentImagePath = savedRelativePath,
            SubmittedBy = req.SubmittedBy
        };

        _db.Kycs.Add(kyc);
        await _db.SaveChangesAsync();

        return Created($"/api/users/{kyc.Id}", new { kyc.Id, kyc.CustomerId });
    }
}

