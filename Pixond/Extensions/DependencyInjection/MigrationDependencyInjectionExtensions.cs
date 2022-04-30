using Pixond.Migration.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Pixond.App.Extensions.DependencyInjection
{
    public static class MigrationDependencyInjectionExtensions
    {
        public static void AddMigrations(this IServiceCollection services)
        {
            services.AddHostedService<DatabaseMigrator>();
        }
    }
}
