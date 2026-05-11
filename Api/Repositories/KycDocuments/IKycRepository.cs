namespace Api.Repositories.KycDocuments
{
    public interface IKycRepository
    {
        Task<KycDto> AddAsync(AddKycDto dto);
    }
}
