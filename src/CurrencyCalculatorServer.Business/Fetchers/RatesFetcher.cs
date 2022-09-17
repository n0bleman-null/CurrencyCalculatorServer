using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CurrencyCalculatorServer.Business.Fetchers
{
    /// <summary>
    /// Fetches rates from external source
    /// </summary>
    public class RatesFetcher : IRatesFetcher
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly FetchingOptions _fetchingOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="RatesFetcher"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="fetchingOptions">The fetching options.</param>
        public RatesFetcher(IHttpClientFactory httpClientFactory, IOptions<FetchingOptions> fetchingOptions)
        {
            _httpClientFactory = httpClientFactory;
            _fetchingOptions = fetchingOptions.Value;
        }

        /// <summary>
        /// Gets the daily rates for today.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// List of rates
        /// </returns>
        /// <exception cref="System.ApplicationException">Error occured during fetching daily rates</exception>
        public async Task<List<RateModel>> GetDailyRatesForToday(CancellationToken token)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(_fetchingOptions.RatesDailyEndpoint, token);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<RateModel>>(json);

            return result ?? throw new ApplicationException("Error occured during fetching daily rates");
        }

        /// <summary>
        /// Gets the monthly rates for this month.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// List of rates
        /// </returns>
        /// <exception cref="System.ApplicationException">Error occured during fetching monthly rates</exception>
        public async Task<List<RateModel>> GetMonthlyRatesForThisMonth(CancellationToken token)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(_fetchingOptions.RatesMonthlyEndpoint, token);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<RateModel>>(json);

            return result ?? throw new ApplicationException("Error occured during fetching monthly rates");
        }
    }
}
