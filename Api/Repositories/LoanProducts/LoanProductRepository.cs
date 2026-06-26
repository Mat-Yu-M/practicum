using Api.Entities.LoanProducts;
using Microsoft.EntityFrameworkCore;
namespace Api.Repositories.LoanProducts;

public sealed class LoanProductRepository(AppDbContext context) : ILoanProductRepository
{
    public async Task<LoanProductDto> AddAsync(AddLoanProductDto dto)
    {
        var entity = new LoanProductEntity
        {
            Name = dto.Name,
            Description = dto.Description,
            LoanCategory = dto.LoanCategory,
            InterestRate = dto.InterestRate,
            MinimumAmount = dto.MinimumAmount,
            MaximumAmount = dto.MaximumAmount,
            MinimumTermMonths = dto.MinimumTermMonths,
            MaximumTermMonths = dto.MaximumTermMonths,
            IsPromotion = dto.IsPromotion,
            CreatedBy = dto.CreatedBy,
            CreatedDateTime = dto.CreatedDateTime,
            ApprovedBy = dto.ApprovedBy,
            ApprovedDateTime = dto.ApprovedDateTime
        };

        context.LoanProducts.Add(entity);
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
        CreatedBy = entity.CreatedBy,
        CreatedDateTime = entity.CreatedDateTime,
        ApprovedBy = entity.ApprovedBy,
        ApprovedDateTime = entity.ApprovedDateTime
    };

    public async Task<IEnumerable<LoanProductDto>> GetAllAsync()
    {
        var entities = await context.LoanProducts.ToListAsync();
        return entities.Select(ToDto);
    }

    public async Task<bool> ExistsByIdAsync(long id)
    {
        return await context.LoanProducts.AnyAsync(lp => lp.Id == id);
    }
}