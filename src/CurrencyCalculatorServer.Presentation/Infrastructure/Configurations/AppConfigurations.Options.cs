using CurrencyCalculatorServer.Business.Options;

namespace CurrencyCalculatorServer.Presentation.Infrastructure.Configurations
{
    public static partial class AppConfigurations
    {
        /// <summary>
        /// Adds the options.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        private static IServiceCollection AddOptions(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<FetchingOptions>(configuration.GetSection(nameof(FetchingOptions)));
            services.Configure<UdpServerOptions>(configuration.GetSection(nameof(UdpServerOptions)));

            return services;
        }
    }
}
