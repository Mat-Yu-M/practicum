using Api.Entities.LoanProducts;
using Api.Repositories.LoanProducts;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanProductController : ControllerBase
    {
        private readonly ILoanProductRepository _repository;
        public LoanProductController(ILoanProductRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> GetLoanProducts()
        {
            var loanProducts = await _repository.GetAllAsync();
            if (!loanProducts.Any())
                return NotFound(new { message = "No Loan Products Found." });
            return Ok(loanProducts.Select(lp => new { lp.Id, lp.Name }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLoanProduct([FromBody] CreateLoanProductRequest req)
        {
            if (await _repository.ExistsByIdAsync(req.Id))
            {
                return Conflict(new { message = "Loan Product ID already in use." });
            }

            var loanProduct = new AddLoanProductDto
            {
                Name = req.Name,
                Description = req.Description,
                LoanCategory = req.LoanCategory,
                MinimumAmount = req.MinimumAmount,
                MaximumAmount = req.MaximumAmount,
                MinimumTermMonths = req.MinimumTermMonths,
                MaximumTermMonths = req.MaximumTermMonths,
                IsPromotion = req.IsPromotion
            };

            await _repository.AddAsync(loanProduct);

            return CreatedAtAction(nameof(GetLoanProducts), new { id = loanProduct.Id }, new { loanProduct.Id });
        }
    }

}

