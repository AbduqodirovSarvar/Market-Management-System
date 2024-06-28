using Application.Extentions;
using Infrastructure.Persistance.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.ConfigureServices();

// Build the application
var app = builder.Build();

// Configure the middleware pipeline
app.ConfigurePipeline();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<AppDbContext>();

try
{
    context.Database.Migrate();
    Console.WriteLine("Migrations applied successfully.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error applying migrations: {ex.Message}");
}

await context.SeedAsync();

app.Run();
