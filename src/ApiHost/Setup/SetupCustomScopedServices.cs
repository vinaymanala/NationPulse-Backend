

using Backend.Core.Interfaces;
using Backend.Core.Services;

namespace Backend.ApiHost.Setup;

public static class SetupCustomScopedServices
{
    public static void AddCustomScopedServices(this IServiceCollection services)
    {
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IDashboardRepository, DashboardRepository>();
        services.AddScoped<IPopulationService, PopulationService>();
        services.AddScoped<IPopulationRepository, PopulationRepository>();
        services.AddScoped<IHealthRepository, HealthRepository>();
        services.AddScoped<IHealthService, HealthService>();
        services.AddScoped<IEconomyRepository, EconomyRepository>();
        services.AddScoped<IEconomyService, EconomyService>();
        services.AddScoped<IPerformanceRepository, PerformanceGrowthRepository>();
        services.AddScoped<IPerformanceService, PerformanceGrowthService>();
    }
}