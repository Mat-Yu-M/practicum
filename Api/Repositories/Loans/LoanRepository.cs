using Api.Entities.Loans;
using Microsoft.EntityFrameworkCore;
namespace Api.Repositories.Loans;

public sealed class LoanRepository(AppDbContext context) : ILoanRepository
{
    public async Task<LoanDto> AddAsync(AddLoanDto dto)
    {
        var entity = new LoanEntity
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

    public async Task<List<LoanEntity>> GetAllAsync()
    {
        return await context.Loans.AsNoTracking().ToListAsync();
    }
}