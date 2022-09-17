namespace CurrencyCalculatorServer.Business.Models
{
    /// <summary>
    /// Database rate model
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public RateType Type { get; set; }

        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public Currency? Currency { get; set; }
    }

    /// <summary>
    /// Rate type
    /// </summary>
    public enum RateType
    {
        /// <summary>
        /// The unspecified
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// The daily
        /// </summary>
        Daily = 1,

        /// <summary>
        /// The monthly
        /// </summary>
        Monthly = 2,
    }
}
