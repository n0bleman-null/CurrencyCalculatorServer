using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Providers;
using Microsoft.EntityFrameworkCore;

namespace CurrencyCalculatorServer.DataAccess.Providers
{
    /// <summary>
    /// Currencies provider
    /// </summary>
    /// <seealso cref="CurrencyCalculatorServer.Business.Providers.ICurrenciesProvider" />
    public class CurrenciesProvider : ICurrenciesProvider
    {
        private readonly DbSet<Currency> _currencies;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesProvider"/> class.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        public CurrenciesProvider(DbSet<Currency> currencies)
        {
            _currencies = currencies;
        }

        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// Currency object or null
        /// </returns>
        public Task<Currency?> GetCurrencyById(int currencyId, CancellationToken token)
        {
            return _currencies.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == currencyId, token);
        }
    }
}
