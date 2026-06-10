using Microsoft.EntityFrameworkCore;
using Api.Entities.Customers;
using Api.Entities.Kycs;
using Api.Entities.Loans;
using Api.Entities.Employees;
using Api.Entities.LoanProducts;
using Api.Entities.EmployeeRequests;
using Api.Entities.EmailDetails;
using Api.Entities.PhoneDetails;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options){
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public virtual DbSet<CustomerEntity> Customers { get; set; } 
    public virtual DbSet<EmailDetailEntity> EmailDetails { get; set; }
    public virtual DbSet<PhoneDetailEntity> PhoneDetails { get; set; }
    public virtual DbSet<EmployeeEntity> Employees { get; set; }
    public virtual DbSet<EmployeeRequestEntity> EmployeeRequests { get; set; }
    public virtual DbSet<KycEntity> Kycs { get; set; }
    public virtual DbSet<LoanEntity> Loans { get; set; } 
    public virtual DbSet<LoanProductEntity> LoanProducts { get; set; }
}