
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Backend.Core.Config;

namespace Backend.Infrastructure;

public partial class AppDbContext : DbContext
{
    private readonly string? _connectionString;

    public AppDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public AppDbContext(IOptions<ApiHostConfig> options)
    {
        _connectionString = options.Value.Database.ResolveConnectionString();
    }

    public AppDbContext(string connectionString, DbContextOptions<AppDbContext> options) : base(options)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    /// Set up the options for the database
    /// </summary
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            return;
        }

        optionsBuilder
            .UseNpgsql(_connectionString, o => o.UseAdminDatabase("postgres"))
            // .UseSnakeCaseNamingConvention()
            .EnableDetailedErrors()
            .EnableSensitiveDataLogging();
    }

}
