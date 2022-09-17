using CurrencyCalculatorServer.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace CurrencyCalculatorServer.Presentation.Infrastructure.Configurations
{
    public static partial class AppConfigurations
    {
        /// <summary>
        /// Configures the application.
        /// </summary>
        /// <param name="appBuilder">The application builder.</param>
        /// <returns></returns>
        public static WebApplicationBuilder ConfigureApplication(this WebApplicationBuilder appBuilder)
        {
            var configuration = appBuilder.Configuration;

            appBuilder.AddSerilogLogger();

            appBuilder.Services
                .AddOptions(configuration)
                .AddInfrastructureServices()
                .AddBusinessLogicServices()
                .AddHostedServices()
                .AddProviders()
                .AddRepositories()
                .AddPostgreSqlContext(options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("CurrenciesDb"));
                });

            return appBuilder;
        }
    }
}
