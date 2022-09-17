using CurrencyCalculatorServer.Business.Models;
using CurrencyCalculatorServer.Business.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace CurrencyCalculatorServer.Business.Fetchers
{
    /// <summary>
    /// Fetches currencies from external source
    /// </summary>
    /// <seealso cref="CurrencyCalculatorServer.Business.Fetchers.ICurrenciesFetcher" />
    public class CurrenciesFetcher : ICurrenciesFetcher
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly FetchingOptions _fetchingOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesFetcher"/> class.
        /// </summary>
        /// <param name="httpClientFactory">The HTTP client factory.</param>
        /// <param name="fetchingOptions">The fetching options.</param>
        public CurrenciesFetcher(IHttpClientFactory httpClientFactory, IOptions<FetchingOptions> fetchingOptions)
        {
            _httpClientFactory = httpClientFactory;
            _fetchingOptions = fetchingOptions.Value;
        }

        /// <summary>
        /// Gets the initial currencies.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// List of CurrencyModels from external source
        /// </returns>
        /// <exception cref="System.ApplicationException">Error occured during fetching currencies list</exception>
        public async Task<List<CurrencyModel>> GetAllCurrencies(CancellationToken token)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(_fetchingOptions.CurrenciesEndpoint, token);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<CurrencyModel>>(json);

            return result ?? throw new ApplicationException("Error occured during fetching currencies list");
        }

        /// <summary>
        /// Gets the initial currencies.
        /// </summary>
        /// <param name="currencyId"></param>
        /// <param name="token">The token.</param>
        /// <returns>
        /// CurrencyModel from external source
        /// </returns>
        /// <exception cref="System.ApplicationException">Error occured during fetching currency</exception>
        public async Task<CurrencyModel> GetCurrency(int currencyId, CancellationToken token)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(_fetchingOptions.CurrenciesEndpoint + currencyId, token);

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<CurrencyModel>(json);

            return result ?? throw new ApplicationException("Error occured during fetching currency");
        }
    }
}
