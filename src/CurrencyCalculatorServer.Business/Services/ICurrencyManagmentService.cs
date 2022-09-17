namespace CurrencyCalculatorServer.Business.Services
{
    /// <summary>
    /// Currency Managment Service
    /// </summary>
    public interface ICurrencyManagmentService
    {
        /// <summary>
        /// Adds the currency.
        /// </summary>
        /// <param name="currencyId">The currency identifier.</param>
        /// <param name="token">The token.</param>
        Task AddCurrencyIfItNotExists(int currencyId, CancellationToken token);
    }
}
