using Api.Entities.Kycs;
namespace Api.Repositories.KycDocuments;

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
        AddressLine1 = dto.AddressLine1,
        AddressLine2 = dto.AddressLine2,
        AddressLine3 = dto.AddressLine3,
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
        AddressLine1 = entity.AddressLine1,
        AddressLine2 = entity.AddressLine2,
        AddressLine3 = entity.AddressLine3,
        DocumentImagePath = entity.DocumentImagePath,
        SubmittedBy = entity.SubmittedBy
    };

}