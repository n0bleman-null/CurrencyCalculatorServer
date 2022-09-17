using CurrencyCalculatorServer.Business.Fetchers;
using CurrencyCalculatorServer.Business.Services;
using CurrencyCalculatorServer.Presentation.Infrastructure.BackgroundServices;

namespace CurrencyCalculatorServer.Presentation.Infrastructure.Configurations
{
    public static partial class AppConfigurations
    {
        /// <summary>
        /// Adds the infrastructure services to service collection
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        /// The service collection.
        /// </returns>
        private static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IRatesFetcher, RatesFetcher>();
            services.AddScoped<ICurrenciesFetcher, CurrenciesFetcher>();
            services.AddAutoMapper(typeof(Program).Assembly);

            return services;
        }

        /// <summary>
        /// Adds the infrastructure services to service collection
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        /// The service collection.
        /// </returns>
        private static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyInitializingService, CurrencyService>();
            services.AddScoped<ICurrencyManagmentService, CurrencyService>();
            services.AddScoped<IRateUpdatingService, RateUpdatingService>();
            services.AddScoped<ICurrencyCalculatorService, CurrencyCalculatorService>();

            return services;
        }

        /// <summary>
        /// Adds the hosted services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>
        /// The service Collection
        /// </returns>
        private static IServiceCollection AddHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<RatesDailyFetchingBackgroundServices>();
            services.AddHostedService<RatesMonthlyFetchingBackgroundServices>();

            return services;
        }
    }
}
