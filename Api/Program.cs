using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options => 
    {options.WithTitle("Practicum API")
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient); }
        );
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
