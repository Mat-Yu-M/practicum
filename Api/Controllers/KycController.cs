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

    [HttpPost("register-customer-documents")]
    public async Task<IActionResult> CreateKyc([FromBody] CreateKycRequest req)
    {
        var addKycDto = new AddKycDto
        {
            CustomerId = req.CustomerId,
            FullName = req.FullName,
            DocumentType = req.DocumentType,
            Country = req.Country,
            ZipCode = req.ZipCode,
            AddressLine = req.AddressLine,
            DocumentImagePath = req.DocumentImagePath, 
            SubmittedBy = req.SubmittedBy
        };

        var resultDto = await _repository.AddAsync(addKycDto);
        return Created($"/api/users/{resultDto.CustomerId}", new { resultDto.CustomerId });
    }
}