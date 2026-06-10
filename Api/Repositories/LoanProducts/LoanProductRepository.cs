using Api.Entities.LoanProducts;
namespace Api.Repositories.LoanProducts;

public sealed class LoanProductRepository(AppDbContext context) : ILoanProductRepository
{
    public async Task<LoanProductDto> AddAsync(AddLoanProductDto dto)
    {
        var entity = new LoanProductEntity
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            LoanCategory = dto.LoanCategory,
            InterestRate = dto.InterestRate,
            MinimumAmount = dto.MinimumAmount,
            MaximumAmount = dto.MaximumAmount,
            MinimumTermMonths = dto.MinimumTermMonths,
            MaximumTermMonths = dto.MaximumTermMonths,
            IsPromotion = dto.IsPromotion,
            CreatedAt = dto.CreatedAt
        };

        context.LoanProduct.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    private static LoanProductDto ToDto(LoanProductEntity entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        LoanCategory = entity.LoanCategory,
        InterestRate = entity.InterestRate,
        MinimumAmount = entity.MinimumAmount,
        MaximumAmount = entity.MaximumAmount,
        MinimumTermMonths = entity.MinimumTermMonths,
        MaximumTermMonths = entity.MaximumTermMonths,
        IsPromotion = entity.IsPromotion,
        CreatedAt = entity.CreatedAt
    };
}