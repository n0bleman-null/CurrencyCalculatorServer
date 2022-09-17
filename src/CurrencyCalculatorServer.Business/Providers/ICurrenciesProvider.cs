using CurrencyCalculatorServer.Business.Models;

namespace CurrencyCalculatorServer.Business.Providers
{
    /// <summary>
    /// Provides currencies from database.
    /// </summary>
    public interface ICurrenciesProvider
    {
        /// <summary>
        /// Gets the currency by identifier.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <param name="token">The token.</param>
        /// <returns>Currency object or null</returns>
        Task<Currency?> GetCurrencyById(int currencyId, CancellationToken token);
    }
}
