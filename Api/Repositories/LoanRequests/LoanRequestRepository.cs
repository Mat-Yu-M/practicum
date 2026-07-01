using Api.Entities.LoanRequests;

namespace Api.Repositories.LoanRequests;

public class LoanRequestRepository(AppDbContext context) : ILoanRequestRepository
{
    public async Task<LoanRequestDto> AddAsync(AddLoanRequestDto dto)
    {
        var entity = new LoanRequestEntity
        {
            CustomerId = dto.CustomerId,
            Name = dto.Name,
            LoanProductId = dto.LoanProductId,
            LoanName = dto.LoanName,
            Amount = dto.Amount,
            InterestRate = dto.InterestRate,
            Status = dto.Status,
            RequestType = dto.RequestType,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            CreatedBy = dto.CreatedBy,
            CreatedDateTime = dto.CreatedDate,
        };

        context.LoanRequests.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    private static LoanRequestDto ToDto(LoanRequestEntity entity) => new()
    {
        Id = entity.Id,
        CustomerId = entity.CustomerId,
        Name = entity.Name,
        LoanProductId = entity.LoanProductId,
        LoanName = entity.LoanName,
        Amount = entity.Amount,
        InterestRate = entity.InterestRate,
        Status = entity.Status,
        RequestType = entity.RequestType,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        CreatedBy = entity.CreatedBy,
        CreatedDateTime = entity.CreatedDateTime
    };


    public async Task<LoanRequestEntity?> DeleteAsync(long id)
    {
        var response = await context.LoanRequests.FindAsync(id);
        if (response == null)
            return null;

        context.LoanRequests.Remove(response);
        await context.SaveChangesAsync();
        return response;
    }


}


