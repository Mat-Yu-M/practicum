using Api.Entities.Kycs;

namespace Api.Repositories.KycDocuments
{
    public interface IKycRepository
    {
        Task<KycDto> AddAsync(AddKycDto dto);
        Task<bool> ExistsAsync(long customerId);
        Task<List<KycEntity>> GetAsync();
        Task<ApproveKycResponse> ApproveAsync(ApproveKycRequest request);
        Task<ApproveKycResponse> RejectAsync(ApproveKycRequest request);
        Task<List<KycEntity>> GetAllAsync();
    }
}
