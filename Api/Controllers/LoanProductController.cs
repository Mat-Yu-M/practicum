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

        [HttpDelete("delete-loan-product")]
        public async Task<IActionResult> RemoveLoanProduct([FromQuery] LoanProductDeleteRequest request)
        {
            var loanProduct = await _repository.DeleteAsync(request);

            if (loanProduct == null)
            {
                return NotFound(new { message = "Loan Product not Found" });
            }
            ;

            var response = new AuditLogResponse(AuditLogType.Delete, "Delete Loan Product", $"Deleted {request.Name}");

            await _auditLogService.LogAsync(response);
            return Ok(loanProduct);
        }


        [HttpPatch("update-loan-product")]
        public async Task<IActionResult> UpdateLoanProduct([FromBody] UpdateLoanProductRequest request)
        {
            var loanProduct = await _repository.GetAsync(request.Id);

            var oldValue = $"{loanProduct.InterestRate} + {loanProduct.MinimumAmount} + {loanProduct.MaximumAmount} + {loanProduct.MinimumTermMonths} + {loanProduct.MaximumTermMonths} + {loanProduct.IsPromotion}";
            var newValue = $"{request.InterestRate} + {request.MinimumAmount} + {request.MaximumAmount} + {request.MinimumTermMonths} + {request.MaximumTermMonths} + {request.IsPromotion}";

            var updatedLoanProduct = await _repository.UpdateAsync(request);


            if (updatedLoanProduct == null)
                return NotFound();

            var response = new AuditLogValueResponse(AuditLogType.Update, oldValue, newValue, "Updated Loan Product", $"Updated {request.Id}");

            return Ok(updatedLoanProduct);
        }
        [HttpGet("get-loan-product")]
        public async Task<IActionResult> GetLoanProduct(long id)
        {
            var loanProduct = await _repository.GetAsync(id);

            if (loanProduct == null)
            {
                return NotFound(new { message = "Account does not exist." });

            }

            var response = new AuditLogResponse(
                    AuditLogType.Fetch,
                    "Loan Product Fetched",
                    $"Loan Product {loanProduct.Name} fetched successfully.");

            await _auditLogService.LogAsync(response);

            return Ok(loanProduct);
        }
    }
}
