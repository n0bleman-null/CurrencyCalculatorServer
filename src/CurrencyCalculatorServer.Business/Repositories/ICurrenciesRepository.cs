using CurrencyCalculatorServer.Business.Models;

namespace CurrencyCalculatorServer.Business.Repositories
{
    /// <summary>
    /// Currencies repository
    /// </summary>
    public interface ICurrenciesRepository
    {
        /// <summary>
        /// Adds the currencies range.
        /// </summary>
        /// <param name="currencies">The currencies.</param>
        /// <param name="token">The token.</param>
        public Task AddRange(IEnumerable<Currency> currencies, CancellationToken token);

        /// <summary>
        /// Adds the specified currency.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <param name="token">The token.</param>
        public Task Add(Currency currency, CancellationToken token);

        /// <summary>
        /// Cleans the currencies table.
        /// </summary>
        /// <param name="token">The token.</param>
        public Task Clear(CancellationToken token);
    }
}
