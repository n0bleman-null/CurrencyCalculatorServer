namespace CurrencyCalculatorServer.Business.Services
{
    /// <summary>
    /// Rate updating service
    /// </summary>
    public interface IRateUpdatingService
    {
        /// <summary>
        /// Updates the daily rates.
        /// </summary>
        /// <param name="token">The token.</param>
        Task UpdateDailyRates(CancellationToken token);

        /// <summary>
        /// Updates the monthly rates.
        /// </summary>
        /// <param name="token">The token.</param>
        Task UpdateMonthlyRates(CancellationToken token);
    }
}
