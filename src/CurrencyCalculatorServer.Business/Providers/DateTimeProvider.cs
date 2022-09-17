namespace CurrencyCalculatorServer.Business.Providers
{
    /// <summary>
    /// Abstraction which provides current datetime.
    /// </summary>
    /// <seealso cref="IDateTimeProvider" />
    public class DateTimeProvider : IDateTimeProvider
    {
        /// <summary>
        /// Gets the now UTC.
        /// </summary>
        /// <value>
        /// The now UTC.
        /// </value>
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
