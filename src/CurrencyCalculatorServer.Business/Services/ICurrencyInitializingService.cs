namespace CurrencyCalculatorServer.Business.Services
{
    /// <summary>
    /// Currency Initializing Service
    /// </summary>
    public interface ICurrencyInitializingService
    {
        /// <summary>
        /// Initializes the currencies.
        /// </summary>
        /// <param name="token">The token.</param>
        Task InitializeCurrencies(CancellationToken token);

        /// <summary>
        /// Clears the currencies table.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        Task Clear(CancellationToken token);
    }
}
