using Pixond.Core.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pixond.App.Extensions.DependencyInjection
{
    public static class ConfigurationDependencyInjectionExtensions
    {

        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            BindDatabaseConfiguration(services, configuration);
        }

        private static void BindDatabaseConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            var databaseConfiguration = new DatabaseConfiguration();
            configuration.Bind("Database", databaseConfiguration);
            services.AddSingleton(databaseConfiguration);

        }
    }
}
