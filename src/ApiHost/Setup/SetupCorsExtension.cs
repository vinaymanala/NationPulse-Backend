
namespace Backend.ApiHost.Setup;

public static class SetupCorsExtension
{
    public static void AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin", policy =>
            {
                policy.WithOrigins("http://localhost:5173") // Replace with your Angular app's URL
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });
    }
}