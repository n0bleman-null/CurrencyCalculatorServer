using CurrencyCalculatorServer.Business.Models;

namespace CurrencyCalculatorServer.Business.Providers
{
    /// <summary>
    /// Provides rates from database.
    /// </summary>
    public interface IRatesProvider
    {
        /// <summary>
        /// Gets rates by day.
        /// </summary>
        /// <param name="planetId">The day.</param>
        /// <param name="token">The token.</param>
        /// <returns>List of rates</returns>
        Task<List<Rate>> GetRatesByDay(DateTime day, CancellationToken token);
    }
}
