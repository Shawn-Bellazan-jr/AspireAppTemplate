using AspireApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AspireApp.WebAPI.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // AutoMapper setup
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Database context setup (SQL Server)
            var connectionString = configuration.GetConnectionString("AspireAppDb");
            services.AddDbContext<AspireAppDbContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }
    }
}
