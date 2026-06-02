using Microsoft.EntityFrameworkCore;
using Api.Entities;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options){
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public virtual DbSet<UserEntity> Users { get; set; } = null;
    public virtual DbSet<EmployeeEntity> Employees { get; set; } = null;
    public virtual DbSet<KycEntity> Kyc { get; set; } = null;
    public virtual DbSet<LoanEntity> Loan { get; set; } = null;
    public virtual DbSet<LoanProductEntity> LoanProduct { get; set; } = null;
}