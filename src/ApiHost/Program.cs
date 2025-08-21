using Backend.Core.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiHostConfig>(builder.Configuration.GetSection(nameof(ApiHostConfig)));

Console.WriteLine("Starting the setup...");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();

