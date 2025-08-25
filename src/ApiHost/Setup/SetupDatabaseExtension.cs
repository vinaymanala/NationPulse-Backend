

using Backend.Infrastructure;

namespace Backend.ApiHost.Setup;

public static class SetupDatabaseExtension
{
    public static void AddDataStore(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
    }
}