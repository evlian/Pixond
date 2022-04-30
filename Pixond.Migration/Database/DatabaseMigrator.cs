using Pixond.Core.Configurations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Pixond.Migration.Database
{
    public class DatabaseMigrator : BackgroundService
    {
        private readonly DatabaseConfiguration _databaseConfiguration;

        public DatabaseMigrator(DatabaseConfiguration databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var serviceProvider = new ServiceCollection()
                                        .AddFluentMigratorCore()
                                        .ConfigureRunner
                                        (
                                            runner => runner
                                                .AddSqlServer()
                                                .WithGlobalConnectionString(_databaseConfiguration.FilmLibraryConnectionString)
                                                .ScanIn(typeof(DatabaseMigrator).Assembly)
                                                .For.Migrations()
                                        )
                                        .AddLogging(logger => logger.AddFluentMigratorConsole())
                                        .BuildServiceProvider(false);

            using (var scope = serviceProvider.CreateScope())
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }

            await Task.CompletedTask;
        }
    }
}
