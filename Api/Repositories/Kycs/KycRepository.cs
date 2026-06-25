using Api.Entities.Kycs;
using Api.Repositories.KycDocuments;
using Microsoft.EntityFrameworkCore;
namespace Api.Repositories.Kycs;

public sealed class KycRepository(AppDbContext context) : IKycRepository
{
    public async Task<KycDto> AddAsync(AddKycDto dto)
    {
        var entity = new KycEntity
        {
            CustomerId = dto.CustomerId,
            FullName = dto.FullName,
            DocumentType = dto.DocumentType,
            Country = dto.Country,
            ZipCode = dto.ZipCode,
            AddressLine = dto.AddressLine,
            DocumentImagePath = dto.DocumentImagePath,
            SubmittedBy = dto.SubmittedBy
        };

        context.Kycs.Add(entity);

        await context.SaveChangesAsync();

        return ToDto(entity);
    }
    public async Task<bool> ExistsAsync(long customerId)
    {
        return await context.Customers.AnyAsync(c => c.Id == customerId);
    }

    public async Task<List<KycEntity>> GetAsync()
    {
        return await context.Kycs.AsNoTracking().ToListAsync();
    }
    private static KycDto ToDto(KycEntity entity) => new()
    {
        Id = entity.Id,
        CustomerId = entity.CustomerId,
        FullName = entity.FullName ?? string.Empty,
        DocumentType = entity.DocumentType,
        Country = entity.Country ?? string.Empty,
        ZipCode = entity.ZipCode ?? string.Empty,
        AddressLine = entity.AddressLine ?? string.Empty,
        DocumentImagePath = entity.DocumentImagePath ?? string.Empty,
        SubmittedBy = entity.SubmittedBy ?? string.Empty
    };
}