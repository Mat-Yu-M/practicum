using Api.Entities.Loans;
using Api.Entities.PhoneDetails;

namespace Api.Repositories.PhoneDetails
{
    public sealed class PhoneDetailRepository(AppDbContext context) : IPhoneDetailRepository
    {
        public async Task<PhoneDetailDto> AddAsync(AddPhoneDetailDto dto)
        {
            var entity = new PhoneDetailEntity
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                Name = dto.Name,
                LoanProductId = dto.LoanProductId,
                LoanName = dto.LoanName,
                Description = dto.Description,
                Amount = dto.Amount,
                InterestRate = dto.InterestRate,
                Status = dto.Status,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                ApprovedDateTime = dto.ApprovedDateTime,
                ApprovedBy = dto.ApprovedBy,
                CreatedBy = dto.CreatedBy,
                CreatedDateTime = dto.CreatedDateTime,
            };

            context.Loans.Add(entity);
            await context.SaveChangesAsync();

            return ToDto(entity);
        }

        private static LoanDto ToDto(LoanEntity entity) => new()
        {
            Id = entity.Id,
            CustomerId = entity.CustomerId,
            Name = entity.Name,
            LoanProductId = entity.LoanProductId,
            LoanName = entity.LoanName,
            Description = entity.Description,
            Amount = entity.Amount,
            InterestRate = entity.InterestRate,
            Status = entity.Status,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            ApprovedDateTime = entity.ApprovedDateTime,
            ApprovedBy = entity.ApprovedBy,
            CreatedBy = entity.CreatedBy,
            CreatedDateTime = entity.CreatedDateTime,
        };

    }
}
