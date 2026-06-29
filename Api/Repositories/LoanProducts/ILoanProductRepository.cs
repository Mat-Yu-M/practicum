using Api.Entities.LoanProducts;

namespace Api.Repositories.LoanProducts
{
    public interface ILoanProductRepository
    {
        Task<LoanProductDto> AddAsync(AddLoanProductDto dto);
        Task<IEnumerable<LoanProductDto>> GetAllAsync();
        Task<bool> ExistsByIdAsync(long id);
        Task<LoanProductEntity?> DeleteAsync(LoanProductDeleteRequest request);
        Task<UpdateLoanProductResponse> UpdateAsync(UpdateLoanProductRequest request);
        Task<LoanProductEntity?> GetAsync(long id);
    }
}