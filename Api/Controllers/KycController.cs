using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Entities.Kycs;
using Api.Repositories.KycDocuments;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KycController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IKycRepository _repository;

    public KycController(AppDbContext db, IKycRepository repository)
    {
        _db = db;
        _repository = repository;
    }

    [HttpPost("documents")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateKyc([FromForm] CreateKycRequest req)
    {
        var customerExists = await _db.Customers.AnyAsync(c => c.Id == req.CustomerId);
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

        var addKycDto = new AddKycDto
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

        var resultDto = await _repository.AddAsync(addKycDto);

        return Created($"/api/users/{resultDto.CustomerId}", new { resultDto.CustomerId });
    }
}