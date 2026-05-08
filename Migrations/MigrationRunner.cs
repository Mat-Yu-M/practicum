using Microsoft.EntityFrameworkCore;

namespace Migrations;

public sealed class MigrationRunner(
    IServiceProvider serviceProvider,
    IHostApplicationLifetime hostApplicationLifetime,
    ILogger<MigrationRunner> logger
) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Starting migrations...");

        var scope = serviceProvider.CreateScope();
        var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        await appDbContext.Database.MigrateAsync(stoppingToken);

        logger.LogInformation("Migration successful");

        hostApplicationLifetime.StopApplication();
    }
}
