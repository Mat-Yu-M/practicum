using Microsoft.EntityFrameworkCore;
using Api.Entities;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{    public DbSet<UserEntity> users { get; set; }
}