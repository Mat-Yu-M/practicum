using Api.Entities.PhoneDetails;

namespace Api.Repositories.PhoneDetails
{
    public sealed class PhoneDetailRepository(AppDbContext context) : IPhoneDetailRepository
    {
        public async Task<PhoneDetailDto> AddAsync(AddPhoneDetailDto dto)
        {
            var entity = new PhoneDetailEntity
            {
                CustomerId = dto.CustomerId,
                PhoneNumber = dto.PhoneNumber,
                CreatedBy = dto.CreatedBy,
                CreatedDateTime = dto.CreatedDateTime,
            };

            context.PhoneDetails.Add(entity);
            await context.SaveChangesAsync();

            return ToDto(entity);
        }

        private static PhoneDetailDto ToDto(PhoneDetailEntity entity) => new()
        {
            CustomerId = entity.CustomerId,
            PhoneNumber = entity.PhoneNumber,
            CreatedBy = entity.CreatedBy,
            CreatedDateTime = entity.CreatedDateTime
        };

    }
}
