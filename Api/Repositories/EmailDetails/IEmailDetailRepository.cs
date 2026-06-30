namespace Api.Repositories.EmailDetails
{
    public interface IEmailDetailRepository
    {
        Task<EmailDetailDto> AddAsync(AddEmailDetailDto dto);
    }
}
