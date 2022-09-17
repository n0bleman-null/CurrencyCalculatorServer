using CurrencyCalculatorServer.Business.Models;

namespace CurrencyCalculatorServer.Business.Services
{
    /// <summary>
    /// Currency calculator service
    /// </summary>
    public interface ICurrencyCalculatorService
    {
        /// <summary>
        /// Converts the currency.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="date">The date.</param>
        /// <param name="token">The token.</param>
        /// <returns>List of GetConversionRatesResponse</returns>
        Task<List<GetConversionRatesResponse>> ConvertCurrency(double quantity, string currencyCode, DateTime date, CancellationToken token);
    }
}
