using AspireApp.Application.Services;
using AspireApp.Core.Interfaces;
using AspireApp.Core.Interfaces.Common;
using AspireApp.Infrastructure;
using AspireApp.Infrastructure.Data;
using AspireApp.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspireApp.WebAPI.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // AutoMapper setup
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Register Unit of Work and Generic Repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();  // Register UnitOfWork for DI
                                                                    // Register Generic Repository and ServiceBase<T>
            services.AddScoped(typeof(IGenericBase<>), typeof(IRepository<>));  // Generic Repository
            services.AddScoped(typeof(IService<>), typeof(ServiceBase<,>));  // Generic Service


            // Database context setup (SQL Server)
            var connectionString = configuration.GetConnectionString("AspireAppDb");
            services.AddDbContext<AspireAppDbContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
