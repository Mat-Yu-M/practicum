using Microsoft.EntityFrameworkCore;
using Migrations;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddWindowsService(o =>
{
    o.ServiceName = "Migrations";
});

builder.AddNpgsqlDbContext<AppDbContext>("practicumdb", configureDbContextOptions: options =>
{
    options.UseSnakeCaseNamingConvention();
});

builder.Services.AddHostedService<MigrationRunner>();

var host = builder.Build();
host.Run();