using Microsoft.EntityFrameworkCore;
using Api.Entities; // Adjust based on your folder name

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // This tells EF Core to create a 'Users' table based on your Entity
    public DbSet<UserEntity> Users { get; set; }
}