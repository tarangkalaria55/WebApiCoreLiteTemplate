using Domain.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence.Contexts;

namespace Persistence.Initializer
{
    public static class DbInitialize
    {
        public static async void Start(IServiceProvider service, DatabaseConfig databaseConfig)
        {
            if (databaseConfig.EnableMigration)
            {
                using (var scope = service.CreateScope())
                {
                    var provider = scope.ServiceProvider;

                    var context = provider.GetRequiredService<EFContext>();

                    if (context.Database.GetPendingMigrations().Any())
                    {
                        await context.Database.MigrateAsync();
                    }
                }
            }
        }
    }
}
