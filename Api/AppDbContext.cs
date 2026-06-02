using Microsoft.EntityFrameworkCore;
using Api.Entities;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options){
    public DbSet<UserEntity> users { get; set; }
    public DbSet<EmployeeEntity> employees { get; set; }
    public DbSet<KycEntity> kyc { get; set; }
}