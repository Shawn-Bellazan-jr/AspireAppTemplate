using AspireApp.Application.Services;
using AspireApp.Core.Interfaces;
using AspireApp.Infrastructure;
using AspireApp.Infrastructure.Data;
using AspireApp.Infrastructure.Interfaces;
using AspireApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace AspireApp.WebAPI.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDocumentationServices(this IServiceCollection services, Assembly assembly)
        {
            var xmlFile = $"{assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(xmlFile);
            


            // Register Swagger services
            services.AddEndpointsApiExplorer();  // Required for minimal APIs in .NET 6+
            services.AddSwaggerGen(options =>
            {
                options.IncludeXmlComments(xmlPath);  // Add XML comments for better API documentation
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "AspireApp API", Version = "v1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "AspireApp API v2", Version = "v2" });
            });

            return services;

        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // AutoMapper setup
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Register Unit of Work and Generic Repositories
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));  // Register UnitOfWork for DI
                                                                    // Register Generic Repository and ServiceBase<T>
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));  // Generic Repository
            services.AddScoped(typeof(IService<,>), typeof(ServiceBase<,>));  // Generic Service


            // Database context setup (SQL Server)
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AspireAppDbContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
