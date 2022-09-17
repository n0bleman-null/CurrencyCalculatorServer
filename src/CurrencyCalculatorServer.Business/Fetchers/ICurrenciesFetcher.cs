using CurrencyCalculatorServer.Business.Models;

namespace CurrencyCalculatorServer.Business.Fetchers
{
    /// <summary>
    /// Fetches currencies from external source
    /// </summary>
    public interface ICurrenciesFetcher
    {
        /// <summary>
        /// Gets the initial currencies.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>List of CurrencyModels from external source</returns>
        Task<List<CurrencyModel>> GetAllCurrencies(CancellationToken token);

        /// <summary>
        /// Gets the initial currencies.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>CurrencyModel from external source</returns>
        Task<CurrencyModel> GetCurrency(int currencyId, CancellationToken token);
    }
}
