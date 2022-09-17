using CurrencyCalculatorServer.Business.Models;

namespace CurrencyCalculatorServer.Business.Fetchers
{
    /// <summary>
    /// Fetches rates from external source
    /// </summary>
    public interface IRatesFetcher
    {
        /// <summary>
        /// Gets the daily rates for today.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>List of rates</returns>
        Task<List<RateModel>> GetDailyRatesForToday(CancellationToken token);

        /// <summary>
        /// Gets the monthly rates for this month.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>List of rates</returns>
        Task<List<RateModel>> GetMonthlyRatesForThisMonth(CancellationToken token);
    }
}
