using Api.Entities;

namespace Api.Repositories.LoanProducts
{
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
                CreatedAt = dto.CreatedAt
            };
            
            context.LoanProduct.Add(entity);
            await context.SaveChangesAsync();

            return ToDto(entity);
        }
    }
}
