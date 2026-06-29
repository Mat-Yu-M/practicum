using Api.Entities.LoanProductRequests;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.LoanProductRequests
{
    public sealed class LoanProductRequestRepository(AppDbContext context) : ILoanProductRequestRepository
    {
        public async Task<LoanProductRequestDto> AddAsync(AddLoanProductRequestDto dto)
        {
            var entity = new LoanProductRequestEntity
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
                RequestType = dto.RequestType,
                CreatedBy = dto.CreatedBy,
                CreatedDateTime = dto.CreatedDateTime
            };

            context.LoanProductRequests.Add(entity);
            await context.SaveChangesAsync();

            return ToDto(entity);
        }

        private static LoanProductRequestDto ToDto(LoanProductRequestEntity entity) => new()
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
            RequestType = entity.RequestType,
            CreatedBy = entity.CreatedBy,
            CreatedDateTime = entity.CreatedDateTime
        };

        public async Task<List<LoanProductRequestEntity>> GetAllAsync()
        {
            return await context.LoanProductRequests.AsNoTracking().ToListAsync();
        }

        public async Task<LoanProductRequestEntity?> DeleteAsync(long id)
        {
            var loanProductRequest = await context.LoanProductRequests.FirstOrDefaultAsync(lpr => lpr.Id == id);

            if (loanProductRequest is null)
                return null;

            context.LoanProductRequests.Remove(loanProductRequest);

            await context.SaveChangesAsync();

            return loanProductRequest;
        }
    }
}
