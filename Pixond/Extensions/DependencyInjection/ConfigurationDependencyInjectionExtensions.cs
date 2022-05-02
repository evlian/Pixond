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
            BindEncryptionConfiguration(services, configuration);
            BindMailServerConfiguration(services, configuration);
        }

        private static void BindDatabaseConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            var databaseConfiguration = new DatabaseConfiguration();
            configuration.Bind("Database", databaseConfiguration);
            services.AddSingleton(databaseConfiguration);
        }

        private static void BindEncryptionConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            var encryptionConfiguration = new EncryptionConfiguration();
            configuration.Bind("Encryption", encryptionConfiguration);
            services.AddSingleton(encryptionConfiguration);
        }

        private static void BindMailServerConfiguration(IServiceCollection services, IConfiguration configuration)
        {
            var mailServerConfiguration = new MailServerConfiguration();
            configuration.Bind("MailServer", mailServerConfiguration);
            services.AddSingleton(mailServerConfiguration);
        }
    }
}
