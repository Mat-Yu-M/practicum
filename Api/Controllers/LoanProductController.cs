using Api.Entities.AuditLogs;
using Api.Entities.LoanProducts;
using Api.Repositories.LoanProducts;
using Api.Services.AuditLogs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanProductController : ControllerBase
    {
        private readonly ILoanProductRepository _repository;
        private readonly IAuditLogService _auditLogService;
        public LoanProductController(ILoanProductRepository repository, IAuditLogService auditLogService)
        {
            _repository = repository;
            _auditLogService = auditLogService;
        }

        [HttpGet("get-loan-products")]
        public async Task<IActionResult> GetLoanProducts()
        {
            var loanProducts = await _repository.GetAllAsync();
            if (!loanProducts.Any())
                return NotFound(new { message = "No Loan Products Found." });

            var response = new AuditLogResponse(AuditLogType.Fetch, "Loan Products Fetched", $"Loan Products Fetched");

            await _auditLogService.LogAsync(response);

            return Ok(loanProducts);
        }

        [HttpPost("add-loan-product")]
        public async Task<IActionResult> CreateLoanProduct([FromBody] CreateLoanProductRequest req)
        {
            var loanProduct = new AddLoanProductDto
            {
                Name = req.Name,
                Description = req.Description,
                LoanCategory = req.LoanCategory,
                InterestRate = req.InterestRate,
                MinimumAmount = req.MinimumAmount,
                MaximumAmount = req.MaximumAmount,
                MinimumTermMonths = req.MinimumTermMonths,
                MaximumTermMonths = req.MaximumTermMonths,
                IsPromotion = req.IsPromotion,
                CreatedBy = req.CreatedBy,
                CreatedDateTime = req.CreatedDateTime,
                ApprovedBy = req.ApprovedBy,
                ApprovedDateTime = req.ApprovedDateTime
            };

            await _repository.AddAsync(loanProduct);

            var response = new AuditLogResponse(AuditLogType.Add,
                "Create Loan Product",
                $"Successfully created loan product with ID: {loanProduct.Name}.");

            await _auditLogService.LogAsync(response);

            return CreatedAtAction(nameof(GetLoanProducts), new { id = loanProduct.Name }, new { loanProduct.Name });
        }
    }

}

