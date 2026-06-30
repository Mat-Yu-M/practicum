using Api.Constants;
using Api.Entities.Kycs;
using Api.Repositories.CustomerStatusHistories;
using Api.Repositories.KycDocuments;
using Microsoft.EntityFrameworkCore;
namespace Api.Repositories.Kycs;

public sealed class KycRepository(AppDbContext context, ICustomerStatusHistoryRepository repository) : IKycRepository
{
    public async Task<KycDto> AddAsync(AddKycDto dto)
    {
        var entity = new KycEntity
        {
            CustomerId = dto.CustomerId,
            FullName = dto.FullName,
            DocumentType = dto.DocumentType,
            Country = dto.Country,
            ZipCode = dto.ZipCode,
            AddressLine = dto.AddressLine,
            DocumentImagePath = dto.DocumentImagePath,
            SubmittedBy = dto.SubmittedBy
        };

        context.Kycs.Add(entity);

        await context.SaveChangesAsync();

        return ToDto(entity);
    }
    public async Task<bool> ExistsAsync(long customerId)
    {
        return await context.Customers.AnyAsync(c => c.Id == customerId);
    }

    public async Task<List<KycEntity>> GetAsync()
    {
        return await context.Kycs.AsNoTracking().ToListAsync();
    }
    private static KycDto ToDto(KycEntity entity) => new()
    {
        Id = entity.Id,
        CustomerId = entity.CustomerId,
        FullName = entity.FullName ?? string.Empty,
        DocumentType = entity.DocumentType,
        Country = entity.Country ?? string.Empty,
        ZipCode = entity.ZipCode ?? string.Empty,
        AddressLine = entity.AddressLine ?? string.Empty,
        DocumentImagePath = entity.DocumentImagePath ?? string.Empty,
        SubmittedBy = entity.SubmittedBy ?? string.Empty
    };

    public async Task<ApproveKycResponse> ApproveAsync(ApproveKycRequest request)
    {
        var document = await context.Kycs.FindAsync(request.Id);

        if (document is null)
        {
            return null;
        }

        context.Entry(document).Property(d => d.ReviewedBy).CurrentValue = request.ReviewedBy;
        context.Entry(document).Property(d => d.ReviewedAt).CurrentValue = request.ReviewedAt;
        context.Entry(document).Property(d => d.Status).CurrentValue = CommonStatus.Approved;


        var response = new ApproveKycResponse
        (
        request.FullName,
        CommonStatus.Approved,
        request.SubmittedBy,
        request.SubmittedAt,
        request.ReviewedBy,
        request.ReviewedAt
        );

        var status = new AddCustomerStatusHistoryDto
        {
            CustomerId = request.CustomerId,
            CustomerName = request.FullName,
            BeforeStatus = CustomerStatus.PendingRequirements,
            AfterStatus = CustomerStatus.Verified,
            CreatedBy = request.ReviewedBy,
            CreatedDateTime = request.ReviewedAt
        };

        await repository.AddAsync(status);

        await context.SaveChangesAsync();

        return response;
    }
    public async Task<ApproveKycResponse> RejectAsync(ApproveKycRequest request)
    {
        var document = await context.Kycs.FindAsync(request.Id);

        if (document is null)
        {
            return null;
        }

        context.Entry(document).Property(d => d.ReviewedBy).CurrentValue = request.ReviewedBy;
        context.Entry(document).Property(d => d.ReviewedAt).CurrentValue = request.ReviewedAt;
        context.Entry(document).Property(d => d.Status).CurrentValue = CommonStatus.Rejected;


        var response = new ApproveKycResponse
        (
        request.FullName,
        CommonStatus.Rejected,
        request.SubmittedBy,
        request.SubmittedAt,
        request.ReviewedBy,
        request.ReviewedAt
        );

        var status = new AddCustomerStatusHistoryDto
        {
            CustomerId = request.CustomerId,
            CustomerName = request.FullName,
            BeforeStatus = CustomerStatus.PendingRequirements,
            AfterStatus = CustomerStatus.RequirementsRejected,
            CreatedBy = request.ReviewedBy,
            CreatedDateTime = request.ReviewedAt
        };

        await repository.AddAsync(status);

        await context.SaveChangesAsync();

        return response;
    }
}