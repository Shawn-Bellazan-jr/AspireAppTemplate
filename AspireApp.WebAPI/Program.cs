using AspireApp.Application.Services;
using AspireApp.Core.Interfaces;
using AspireApp.Core.Interfaces.Common;
using AspireApp.Infrastructure;
using AspireApp.Infrastructure.Data;
using AspireApp.Infrastructure.Interfaces;
using AspireApp.WebAPI.Extentions;
using AspireApp.WebAPI.MappingProfiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();

// Register Unit of Work and Generic Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();  // Register UnitOfWork for DI
// Register Generic Repository and ServiceBase<T>
builder.Services.AddScoped(typeof(IGenericBase<>), typeof(IRepository<>));  // Generic Repository
builder.Services.AddScoped(typeof(IService<>), typeof(ServiceBase<>));  // Generic Service


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
