
namespace Backend.ApiHost.Setup;

public static class SetupControllerExtension
{
    public static void AddCustomControllers(this IServiceCollection services)
    {
        services.AddControllers();
    }
}