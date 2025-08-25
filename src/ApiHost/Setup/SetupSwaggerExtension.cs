
using Backend.Core.Utils;

namespace Backend.ApiHost.Setup;

public static class SetupSwaggerExtension
{
    public static void AddCustomSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {

            var filePath = Path.Combine(AppContext.BaseDirectory, "core.xml");

            config.IncludeXmlComments(filePath);

            config.DescribeAllParametersInCamelCase();

            config.SwaggerDoc(
                "v1-dashboard",
                new()
                {
                    Version = "v1",
                    Title = "Dashboard API",
                    Contact = new() { Name = "Backend Dashboard API" }
                }
            );

            config.SwaggerDoc(
                "v1-population",
                new()
                {
                    Version = "v1",
                    Title = "Population API",
                    Contact = new() { Name = "Backend Population API" }
                }
            );

            config.SwaggerDoc(
                "v1-health",
                new()
                {
                    Version = "v1",
                    Title = "Health API",
                    Contact = new() { Name = "Backend Health API" }
                }
            );

            config.SwaggerDoc(
                "v1-economy",
                new()
                {
                    Version = "v1",
                    Title = "Economy API",
                    Contact = new() { Name = "Backend Economy API" }
                }
            );

            config.SwaggerDoc(
                "v1-employment",
                new()
                {
                    Version = "v1",
                    Title = "Employment API",
                    Contact = new() { Name = "Backend Employment API" }
                }
            );

            config.SwaggerDoc(
                "v1-performance",
                new()
                {
                    Version = "v1",
                    Title = "Performance API",
                    Contact = new() { Name = "Backend Performance API" }
                }
            );

            config.DocInclusionPredicate(
                (name, def) =>
                {
                    if (name == "v1-dashboard")
                    {
                        // Only return true if it's an admin route
                        return def.GroupName == Constants.DashboardApiGroup;
                    }

                    if (name == "v1-population")
                    {
                        // Only return true if it's a default API group
                        return def.GroupName == Constants.PopulationApiGroup;
                    }

                    if (name == "v1-health")
                    {
                        // Only return true if it's a reporting API group
                        return def.GroupName == Constants.HealthApiGroup;
                    }

                    if (name == "v1-economy")
                    {
                        // Only return true if it's a reporting API group
                        return def.GroupName == Constants.EconomyApiGroup;
                    }

                    if (name == "v1-employment")
                    {
                        // Only return true if it's a reporting API group
                        return def.GroupName == Constants.EmploymentApiGroup;
                    }

                    if (name == "v1-performance")
                    {
                        // Only return true if it's a reporting API group
                        return def.GroupName == Constants.PerformanceApiGroup;
                    }

                    // Untagged endpoints are counted as the default API
                    return false;
                }
            );
        });
    }
}