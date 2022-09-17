using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Providers;

namespace CurrencyCalculatorServer.Business.Services
{
    /// <summary>
    /// Currency calculator service
    /// </summary>
    /// <seealso cref="CurrencyCalculatorServer.Business.Services.ICurrencyCalculatorService" />
    public class CurrencyCalculatorService : ICurrencyCalculatorService
    {
        private readonly IRatesProvider _ratesProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyCalculatorService"/> class.
        /// </summary>
        /// <param name="ratesProvider">The rates provider.</param>
        public CurrencyCalculatorService(IRatesProvider ratesProvider)
        {
            _ratesProvider = ratesProvider;
        }

        /// <summary>
        /// Converts the currency.
        /// </summary>
        /// <param name="quantity">The quantity.</param>
        /// <param name="currencyCode">The currency code.</param>
        /// <param name="date">The date.</param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// List of GetConversionRatesResponse
        /// </returns>
        /// <exception cref="System.ApplicationException">Unknown currency</exception>
        public async Task<List<GetConversionRatesResponse>> ConvertCurrency(double quantity, string currencyCode, DateTime date, CancellationToken token)
        {
            var rates = await _ratesProvider.GetRatesByDay(date, token);

            var targetRate = rates.FirstOrDefault(e => e.Currency!.Abbreviation == currencyCode);

            if (targetRate == null)
                throw new ApplicationException("Unknown currency");

            var total = targetRate.Price * Convert.ToDecimal(quantity);

            var result = rates.Select(e => new GetConversionRatesResponse
            {
                Abbreviation = e.Currency!.Abbreviation!,
                Value = total / e.Price
            }).ToList();

            return result;
        }
    }
}
