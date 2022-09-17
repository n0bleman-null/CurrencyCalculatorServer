using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CurrencyCalculatorServer.DataAccess.Repositories
{
    /// <summary>
    /// Currencies repository
    /// </summary>
    /// <seealso cref="CurrencyCalculatorServer.Business.Repositories.ICurrenciesRepository" />
    public class CurrenciesRepository : ICurrenciesRepository
    {
        private readonly DbSet<Currency> _currencies;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesRepository"/> class.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        public CurrenciesRepository(DbSet<Currency> currencies)
        {
            _currencies = currencies;
        }

        /// <summary>
        /// Adds the specified currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <param name="token">The token.</param>
        public Task Add(Currency currency, CancellationToken token)
        {
            _currencies.Add(currency);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Adds the currencies range.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        /// <param name="token">The token.</param>
        public Task AddRange(IEnumerable<Currency> currencies, CancellationToken token)
        {
            _currencies.AddRange(currencies);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Cleans the currencies table.
        /// </summary>
        /// <param name="token">The token.</param>
        public Task Clear(CancellationToken token)
        {
            _currencies.RemoveRange(_currencies);

            return Task.CompletedTask;
        }
    }
}
