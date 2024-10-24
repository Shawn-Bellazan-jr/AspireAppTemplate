using AspireApp.Application.Services;
using AspireApp.Core.Interfaces;
using AspireApp.Core.Interfaces.Common;
using AspireApp.Infrastructure;
using AspireApp.Infrastructure.Data;
using AspireApp.Infrastructure.Interfaces;
using AspireApp.WebAPI.Extentions;
using AspireApp.WebAPI.MappingProfiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDocumentationServices(Assembly.GetExecutingAssembly());
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve Swagger UI in development
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspireApp API v1");
        c.RoutePrefix = string.Empty;  // Set Swagger UI to appear at the root
    });
}
app.MapControllers();
app.UseHttpsRedirection();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
