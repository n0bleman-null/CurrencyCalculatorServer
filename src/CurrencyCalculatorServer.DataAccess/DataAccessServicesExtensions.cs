using CurrencyCalculatorServer.Business;
using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Providers;
using CurrencyCalculatorServer.Business.Repositories;
using CurrencyCalculatorServer.DataAccess.Providers;
using CurrencyCalculatorServer.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyCalculatorServer.DataAccess
{
    /// <summary>
    /// Data Access Dependency Injection Extensions
    /// </summary>
    public static class DataAccessServicesExtensions
    {
        /// <summary>Register the sql providers in service collection.</summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        ///   The service collection.
        /// </returns>
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<ICurrenciesProvider, CurrenciesProvider>();
            services.AddScoped<IRatesProvider, RatesProvider>();

            return services;
        }

        /// <summary>
        /// Register the sql repositories in service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>
        /// The service collection.
        /// </returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICurrenciesRepository, CurrenciesRepository>();
            services.AddScoped<IRatesRepository, RatesRepository>();

            return services;
        }

        /// <summary>
        /// Register the PostgreSQL database context <see cref="CurrencyDbContext" /> class
        /// and context dependencies in service collection.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The service collection.
        /// </returns>
        public static IServiceCollection AddPostgreSqlContext(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContextPool<CurrencyDbContext>(options);
            services.AddScoped<IDataContext, CurrencyDataContext>();
            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<CurrencyDbContext>().Set<Currency>());
            services.AddScoped(serviceProvider =>
                serviceProvider.GetRequiredService<CurrencyDbContext>().Set<Rate>());

            return services;
        }
    }
}
