using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Domain.Settings;

namespace Persistence
{
    public static class Startup
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, DatabaseConfig? databaseConfig)
        {
            if (databaseConfig == null || databaseConfig.Connection == null) throw new Exception("Database not configured");

            services.AddDbContext<EFContext>(options => options.UseSqlServer(databaseConfig.Connection));

            return services;
        }
    }
}
