using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Constants;
using Api.Entities.Customers;

[ApiController]
[Route("api/[controller]")]

public class CustomerController : ControllerBase
{
    private readonly AppDbContext _db;
    public CustomerController(AppDbContext db) => _db = db;

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest req)
    {
        if (await _db.Customers.AnyAsync(c => c.Id.ToString() == req.Id))
            return Conflict(new { message = "Customer ID already in use." });

        var customer = new CustomerEntity
        {
            FirstName = req.FirstName,
            MiddleName = req.MiddleName,
            LastName = req.LastName,
            Balance = req.Balance
        };

        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();

        return Created($"/api/customers/{customer.Id}", new { customer.Id });
    }


    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _db.Customers.ToListAsync();

        if (customers == null)
            return NotFound(new { message = "No customers found." });

        return Ok(customers.Select(c => new { c.Id, c.FirstName, c.LastName, c.Status, c.Balance }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(long id, [FromBody] UpdateCustomerRequest req)
    {
        var customer = await _db.Customers.FindAsync(id);

        if (customer == null)
            return NotFound(new { message = "Customer not found." });

        customer.FirstName = req.FirstName;
        customer.MiddleName = req.MiddleName;
        customer.LastName = req.LastName;
        customer.Balance = req.Balance;
        customer.Status = req.Status;

        await _db.SaveChangesAsync();

        return Ok(new { customer.Id, customer.FirstName, customer.LastName, customer.Balance });
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateCustomerStatus(long id, [FromBody] UpdateCustomerStatusRequest req)
    {
        var customer = await _db.Customers.FindAsync(id);

        if (customer == null)
            return NotFound(new { message = "Customer not found." });

        customer.Status = req.Status;

        await _db.SaveChangesAsync();

        return Ok(new { customer.Id, customer.Status });
    }

    [HttpPut("{id}/balance")]
    public async Task<IActionResult> UpdateCustomerBalance(long id, [FromBody] UpdateBalanceRequest req)
    {
        var user = await _db.Customers.FindAsync(id);

        if (user == null)
            return NotFound(new { message = "User not found." });

        user.Balance = req.Balance;


        await _db.SaveChangesAsync();

        return Ok(new { user.Id, user.Balance });
    }
}