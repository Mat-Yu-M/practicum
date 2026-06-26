using Api.Entities.LoanProductRequests;

namespace Api.Repositories.LoanProductRequests;

public interface ILoanProductRequestRepository
{
    Task<LoanProductRequestDto> AddAsync(AddLoanProductRequestDto dto);
    Task<List<LoanProductRequestEntity>> GetAllAsync();
}