using Microsoft.EntityFrameworkCore;
using Api.Entities;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options){    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<EmployeeEntity> Employees { get; set; }
}