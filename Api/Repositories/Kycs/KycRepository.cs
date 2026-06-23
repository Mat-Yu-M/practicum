using Api.Entities.Kycs;
namespace Api.Repositories.KycDocuments;

public sealed class KycRepository(AppDbContext context) : IKycRepository
{
    public async Task<KycDto> AddAsync(AddKycDto dto)
    {
        var entity = new KycEntity
        {
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

    private static KycDto ToDto(KycEntity entity) => new()
    {
        Id = entity.Id,
        CustomerId = entity.CustomerId,
        FullName = entity.FullName,
        DocumentType = entity.DocumentType,
        Country = entity.Country,
        ZipCode = entity.ZipCode,
        AddressLine = entity.AddressLine,
        DocumentImagePath = entity.DocumentImagePath,
        SubmittedBy = entity.SubmittedBy
    };

}