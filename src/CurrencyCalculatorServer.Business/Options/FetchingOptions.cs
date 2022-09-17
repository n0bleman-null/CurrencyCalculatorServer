namespace CurrencyCalculatorServer.Business.Options
{
    /// <summary>
    /// Fetching options
    /// </summary>
    public class FetchingOptions
    {
        /// <summary>
        /// Gets or sets the currencies endpoint.
        /// </summary>
        /// <value>
        /// The currencies endpoint.
        /// </value>
        public string? CurrenciesEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the rates daily endpoint.
        /// </summary>
        /// <value>
        /// The rates daily endpoint.
        /// </value>
        public string? RatesDailyEndpoint { get; set; }

        /// <summary>
        /// Gets or sets the rates monthly endpoint.
        /// </summary>
        /// <value>
        /// The rates monthly endpoint.
        /// </value>
        public string? RatesMonthlyEndpoint { get; set; }
    }
}
