namespace Api.Repositories.CustomerLoanHistories
{
    public sealed class CustomerLoanHistoryRepository(AppDbContext context) : ICustomerLoanHistoryRepository
    {
        public async Task<CustomerLoanHistoryDto> AddAsync(AddCustomerLoanHistoryDto dto)
        {
            var entity = new CustomerLoanHistoryEntity
            {
                CustomerId = dto.CustomerId,
                LoanId = dto.LoanId,
                LoanAmount = dto.LoanAmount,
                Status = dto.Status,
                RepaymentScheduleId = dto.RepaymentScheduleId,
                DueDate = dto.DueDate,
                CreatedBy = dto.CreatedBy,
                CreatedDateTime = dto.CreatedDateTime,
                ApprovedBy = dto.ApprovedBy,
                ApprovedAt = dto.ApprovedAt,
            };

            context.CustomerLoanHistories.Add(entity);
            await context.SaveChangesAsync();

            return ToDto(entity);
        }
        private static CustomerLoanHistoryDto ToDto(CustomerLoanHistoryEntity entity) => new()
        {
            CustomerId = entity.CustomerId,
            LoanId = entity.LoanId,
            LoanAmount = entity.LoanAmount,
            Status = entity.Status,
            RepaymentScheduleId = entity.RepaymentScheduleId,
            DueDate = entity.DueDate,
            CreatedBy = entity.CreatedBy,
            CreatedDateTime = entity.CreatedDateTime,
            ApprovedBy = entity.ApprovedBy,
            ApprovedAt = entity.ApprovedAt,
        };
    }
}
