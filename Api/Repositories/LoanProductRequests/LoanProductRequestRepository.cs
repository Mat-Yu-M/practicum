using Api.Constants;
using Api.Entities.LoanProductRequests;
using Api.Entities.LoanProducts;
using Api.Repositories.LoanProducts;

namespace Api.Repositories.LoanProductRequests
{
    public sealed class LoanProductRequestRepository(AppDbContext context) : ILoanProductRequestRepository
    {
        public async Task<LoanProductRequestDto> AddAsync(AddLoanProductRequestDto dto)
        {
            var entity = new LoanProductRequestEntity
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
                RequestType = dto.RequestType,
                CreatedAt = dto.CreatedAt
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
            CreatedAt = entity.CreatedAt
        };
    }
}
