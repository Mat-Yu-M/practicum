namespace Api.Repositories.PhoneDetails
{
    public interface IPhoneDetailRepository
    {
        Task<PhoneDetailDto> AddAsync(AddPhoneDetailDto dto);
    }
}
