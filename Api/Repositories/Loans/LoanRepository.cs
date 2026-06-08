using Api.Entities;
namespace Api.Repositories.Loans;

public sealed class LoanRepository(AppDbContext context) : ILoanRepository
{
    public async Task<LoanDto> AddAsync(AddLoanDto dto)
    {
        var entity = new LoanEntity
        {
            Id = dto.Id,
            UserId = dto.UserId,
            Name = dto.Name, 
            LoanProductId = dto.LoanProductId,
            LoanName = dto.LoanName,
            Description= dto.Description,
            Amount = dto.Amount,
            InterestRate= dto.InterestRate,
            Status = dto.Status,
            StartDate=dto.StartDate,
            EndDate = dto.EndDate,
            ApprovedDate=dto.ApprovedDate,
            ApprovedBy=dto.ApprovedBy,
            CreatedDate=dto.CreatedDate,
        };

        context.Loan.Add(entity);
        await context.SaveChangesAsync();

        return ToDto(entity);
    }

    private static LoanDto ToDto(LoanEntity entity) => new()
    {
        Id = entity.Id,
        UserId = entity.UserId,
        Name = entity.Name,
        LoanProductId= entity.LoanProductId,
        LoanName = entity.LoanName,
        Description = entity.Description,
        Amount= entity.Amount,
        InterestRate = entity.InterestRate,
        Status = entity.Status,
        StartDate=entity.StartDate,
        EndDate= entity.EndDate,
        ApprovedDate=entity.ApprovedDate,
        ApprovedBy = entity.ApprovedBy,
        CreatedDate = entity.CreatedDate,
    };

}