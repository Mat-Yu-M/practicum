using Microsoft.EntityFrameworkCore;
using Api.Entities.Customers;
using Api.Entities.Kycs;
using Api.Entities.Loans;
using Api.Entities.Employees;
using Api.Entities.LoanProducts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options){
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public virtual DbSet<CustomerEntity> Customers { get; set; } 
    public virtual DbSet<EmployeeEntity> Employees { get; set; } 
    public virtual DbSet<KycEntity> Kyc { get; set; }
    public virtual DbSet<LoanEntity> Loan { get; set; } 
    public virtual DbSet<LoanProductEntity> LoanProduct { get; set; }
}