using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Entities.Kycs;
using Api.Repositories.KycDocuments;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KycController : ControllerBase
{
    private readonly IKycRepository _repository;

    public KycController(IKycRepository repository) => _repository = repository;


    [HttpPost("register-customer-documents")]
    public async Task<IActionResult> CreateKyc([FromBody] CreateKycRequest req)
    {
        var customerExists = await _repository.ExistsAsync(req.CustomerId); 

        if (!customerExists)
        {
            return NotFound($"Customer with ID {req.CustomerId} does not exist.");
        }

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

    [HttpGet("get-customer-documents")]
    public async Task<IActionResult> GetKycs()
    {
        var kycs = await _repository.GetAsync();
        return Ok(kycs);

    }
}