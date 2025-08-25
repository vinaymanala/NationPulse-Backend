using Backend.Core.Config;
using Backend.ApiHost.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiHostConfig>(builder.Configuration.GetSection(nameof(ApiHostConfig)));

Console.WriteLine("Starting the setup...");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();
builder.Services.AddDataStore();
builder.Services.AddCustomControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
    {
        options.ShowCommonExtensions();
        //* 👇 Note that we set up 6 endpoints for the different services.
        options.SwaggerEndpoint("v1-dashboard/swagger.json", "Dashboard API");
        options.SwaggerEndpoint("v1-population/swagger.json", "Population API");
        options.SwaggerEndpoint("v1-health/swagger.json", "Health API");
        options.SwaggerEndpoint("v1-economy/swagger.json", "Economy API");
        options.SwaggerEndpoint("v1-employment/swagger.json", "Employment API");
        options.SwaggerEndpoint("v1-performance/swagger.json", "Performance API");
    });

app.MapControllers();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();


