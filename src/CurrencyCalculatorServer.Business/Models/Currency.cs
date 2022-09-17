namespace CurrencyCalculatorServer.Business.Models
{
    /// <summary>
    /// Database currency model
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the abbreviation.
        /// </summary>
        /// <value>
        /// The abbreviation.
        /// </value>
        public string? Abbreviation { get; set; }

        /// <summary>
        /// Gets or sets the date start.
        /// </summary>
        /// <value>
        /// The date start.
        /// </value>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Gets or sets the date end.
        /// </summary>
        /// <value>
        /// The date end.
        /// </value>
        public DateTime DateEnd { get; set; }

        /// <summary>
        /// Gets or sets the rates.
        /// </summary>
        /// <value>
        /// The rates.
        /// </value>
        public List<Rate>? Rates { get; set; }
    }
}
