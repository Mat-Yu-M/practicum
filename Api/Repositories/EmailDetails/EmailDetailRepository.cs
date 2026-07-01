using Api.Entities.EmailDetails;

namespace Api.Repositories.EmailDetails
{
    public sealed class EmailDetailRepository(AppDbContext context) : IEmailDetailRepository
    {
        public async Task<EmailDetailDto> AddAsync(AddEmailDetailDto dto)
        {

            var entity = new EmailDetailEntity
            {
                CustomerId = dto.CustomerId,
                Email = dto.Email,
                CreatedBy = dto.CreatedBy,
                CreatedDateTime = dto.CreatedDateTime
            };

            context.EmailDetails.Add(entity);
            await context.SaveChangesAsync();

            return ToDto(entity);
        }

        private static EmailDetailDto ToDto(EmailDetailEntity entity) => new()
        {
            CustomerId = entity.CustomerId,
            Email = entity.Email,
            CreatedBy = entity.CreatedBy,
            CreatedDateTime = entity.CreatedDateTime,
        };
    }
}
